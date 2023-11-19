import os
import sys
from re import sub
from github import Github
from termcolor import cprint
import json
import requests

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
    argv = sys.argv
    args = {}
    
    for i in range(len(argv)):
        if (not argv[i].startswith("--")):
            continue
        
        name = argv[i].split("=")[0].replace("--", "")
        value = argv[i].split("=")[1]
        args[name] = value
        
    return args            


def createPr(): 
    if (not is_cron_job):
        cprint("Not a cron job. No pull request will be created.", 'green')
        return

    cprint("Creating PR...", 'green')

    args = getArgs()
    cprint(args)

    
    if not args.get('token') or not args.get('source_branch') or not args.get('target_branch') or not args.get('repo_name') or not args.get('repo_owner'):
        cprint("One or more required arguments are missing. No pull request will be created. Required arguments: token, source_branch, target_branch, repo_name, repo_owner", 'red')
        return
    

    g = Github(args.get('token'))
    
    repo = g.get_repo(args.get('repo_name'))
    print(repo)
    
    source = repo.get_branch(args.get('source_branch'))
    
    print(source)
    repo.create_git_ref(ref='refs/heads/' + 'robots-ci', sha=source.commit.sha)
    repo.update_file('README.md', "🤖 README.md update", content, repo.get_contents(git_file, ref='new-branch').sha, branch='new-branch')

    pr = repo.create_pull(
        title='🤖 Update README.md',
        body='Modifications to README',
        head='robots-ci',
        base='master'
    )
    
    print(pr)

createPr()    