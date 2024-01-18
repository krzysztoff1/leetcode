import os
import requests
from re import sub
from termcolor import cprint
from create_pr import createPr

api_url = 'https://leetcode.com/api/problems/all/'
response = requests.get(api_url)
response = response.json()
data = response['stat_status_pairs']

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
    f.write('''# Personal LeetCode Solutions

Used only for learning purposes. Solutions are not optimal.

> [!NOTE]  
> This readme is automatically updated using CI.

## Solutions\n
''')

    for dir in dirs:
        f.write(f'### {getPrettyLangName(dir)}\n\n')
        f.write(f'| Title | Link | Difficulty |\n')
        f.write(f'| ----- | ---- | ---------- |\n')

        problems = getProblemsFromDir(dir)
        problems.sort()
        
        for problem in problems:
            link = 'https://leetcode.com/problems/' + kebab(problem)
            problem_data = [d for d in data if d['stat']['question__title_slug'] == kebab(problem)][0]

            difficulty = problem_data['difficulty']['level']
            difficulty_map = [
                '$${\color{green}Easy}$$',
                '$${\color{orange}Medium}$$',
                '$${\color{red}Hard}$$',
            ]

            difficulty = difficulty_map[difficulty - 1]
            title = problem_data['stat']['question__title']
            solution_link = './leetcode/tree/master/' + dir + '/' + problem

            f.write(f'| [{title}]({solution_link}) | [View]({link}) | {difficulty} |\n')

        f.write('\n')

with open('README.md', 'r') as file:
    content = file.read()

createPr(content)