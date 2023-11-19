from re import sub
import os
from github import Github, InputGitTreeElement
from termcolor import cprint
import argparse

is_cron_job = os.environ.get('GITHUB_ACTIONS') == 'true'

def kebab(s):
    return '-'.join(
        sub(r"(\s|_|-)+"," ",
        sub(r"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+",
        lambda mo: ' ' + mo.group(0).lower(), s)).split())

def getPrettyLangName(lang):
    if lang == 'csharp':
        return 'C#'
    else:
        return lang.capitalize()

def getProblemsFromDir(dir): 
    problems = [d for d in os.listdir(dir) if os.path.isdir(f'{dir}/{d}')]
    problems = [d for d in problems if not d.startswith('.')]
    return problems

dirs = [d for d in os.listdir('.') if os.path.isdir(d)]
dirs = [d for d in dirs if not d.startswith('.')]

# print pretty table of solutions using termcolor

cprint('Personal LeetCode Solutions', 'green', 'on_green', attrs=['bold'])
cprint('')
cprint('Solutions:', 'green', attrs=['bold'])
cprint('')

for dir in dirs:
    cprint(f'{getPrettyLangName(dir)}', 'green', attrs=['underline'])
    problems = getProblemsFromDir(dir)
    problems = ', '.join(problems)
    cprint(f'{problems}', 'blue')
    cprint('')

# create readme with links to all solutions
with open('README.md', 'w') as f:
    f.write('# Personal LeetCode Solutions\n\n')
    f.write('## Solutions\n\n')
    for dir in dirs:
        f.write(f'### {getPrettyLangName(dir)}\n\n')
        f.write(f'| # | Title | Solution | Link |\n')
        f.write(f'|---| ----- | -------- | ---- |\n')
        problems = getProblemsFromDir(dir)
        problems.sort()
        
        for problem in problems:
            f.write(f'| {problem} | [{problem}](./{dir}/{problem}) | [Solution](./{dir}/{problem}) | [Link](https://leetcode.com/problems/{kebab(problem)}) |\n')
            
        f.write('\n')

with open('README.md', 'r') as file:
    content = file.read()

def getArgs():
    parser = argparse.ArgumentParser(description='Process command line arguments.')

    # Define the arguments
    parser.add_argument('--token', type=str, required=True, help='GitHub API token')
    parser.add_argument('--source_branch', type=str, required=True, help='Source branch name')
    parser.add_argument('--target_branch', type=str, required=True, help='Target branch name')
    parser.add_argument('--repo_name', type=str, required=True, help='Repository name')
    parser.add_argument('--repo_owner', type=str, required=True, help='Repository owner')

    # Parse the arguments
    args = parser.parse_args()

    # Print or use the arguments as needed
    print(f"Token: {args.token}")
    print(f"Source Branch: {args.source_branch}")
    print(f"Target Branch: {args.target_branch}")
    print(f"Repository Name: {args.repo_name}")
    print(f"Repository Owner: {args.repo_owner}")
    
    return args


def createPr(): 
    if (not is_cron_job):
        cprint("Not a cron job. No pull request will be created.", 'green')
        return

    cprint("Creating PR...", 'green')

    args = getArgs()
    token = args.token
    source_branch = args.source_branch
    target_branch = args.target_branch
    repo_name = args.repo_name
    repo_owner = args.repo_owner
    
    if not token or not source_branch or not target_branch or not repo_name or not repo_owner:
        cprint("One or more required arguments are missing. No pull request will be created. Required arguments: token, source_branch, target_branch, repo_name, repo_owner", 'red')
        return
    
    if source_branch == target_branch:
        cprint("Source and target branches are the same. No pull request will be created.", 'red')
        return

    cprint("source_branch: " + source_branch, 'green')
    cprint("target_branch: " + target_branch, 'green')
    cprint("repo_name: " + repo_name, 'green')
    cprint("repo_owner: " + repo_owner, 'green')
    
    # g = Github(token)
    # repo = g.get_user().get_repo(repo_name)
    # source = repo.get_branch(source_branch)
    # repo.create_git_ref(ref='refs/heads/' + target_branch, sha=source.commit.sha)
    # git_file = 'README.md'
    # repo.update_file(git_file, "🤖 README.md update", content, repo.get_contents(git_file, ref='new-branch').sha, branch='new-branch')

    # # Create a pull request
    # pr = repo.create_pull(
    #     title='🤖 Update README.md',
    #     body='Modifications to README',
    #     head='new-branch',
    #     base='main'
    # )
    
    # print(pr)

createPr()    