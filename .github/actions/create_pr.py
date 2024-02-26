import sys
import os
from github import Github
from termcolor import cprint


def getArgs():
    argv = sys.argv
    args = {}

    for i in range(len(argv)):
        if not argv[i].startswith("--"):
            continue

        name = argv[i].split("=")[0].replace("--", "")
        value = argv[i].split("=")[1]
        args[name] = value

    return args


def createPr(content):
    is_cron_job = os.environ.get("GITHUB_ACTIONS") == "true"

    if not is_cron_job:
        cprint("Not a cron job. No pull request will be created.", "green")
        return

    cprint("Creating PR...", "green")

    args = getArgs()
    cprint(args)

    if (
        not args.get("token")
        or not args.get("source_branch")
        or not args.get("target_branch")
        or not args.get("repo_name")
        or not args.get("repo_owner")
    ):
        cprint(
            "One or more required arguments are missing. No pull request will be created. Required arguments: token, source_branch, target_branch, repo_name, repo_owner",
            "red",
        )
        return

    g = Github(args.get("token"))

    robot_branch_name = "robots-ci-branch"

    try:
        repo = g.get_repo(args.get("repo_name"))
        repo.get_branch(robot_branch_name)
        repo.get_git_ref(f"heads/{robot_branch_name}").delete()
    except:
        pass

    try:
        repo = g.get_repo(args.get("repo_name"))
        prs = repo.get_pulls(
            state="open", head=f'{args.get("repo_owner")}:{robot_branch_name}'
        )
        for pr in prs:
            pr.edit(state="closed")
    except:
        pass

    repo = g.get_repo(args.get("repo_name"))
    source = repo.get_branch(args.get("source_branch"))

    current_readme_content = repo.get_contents(
        "README.md", ref=args.get("target_branch")
    )

    if current_readme_content.decoded_content.decode("utf-8") == content:
        cprint("No changes to README.md. No pull request will be created.", "green")
        return

    repo.create_git_ref(ref="refs/heads/" + robot_branch_name, sha=source.commit.sha)

    git_file = "README.md"

    repo.update_file(
        git_file,
        "🤖 README.md update",
        content,
        repo.get_contents(git_file, ref=robot_branch_name).sha,
        branch=robot_branch_name,
    )

    pr = repo.create_pull(
        title="🤖 Update README.md",
        body="Modifications to README",
        head=robot_branch_name,
        base=args.get("target_branch"),
    )

    if pr:
        cprint("PR created!", "green")
