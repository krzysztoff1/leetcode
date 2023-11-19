from re import sub
import os

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

print(f"Dirs: {dirs}")
print(f"Total LeetCode Solutions: {len(dirs)}") 

# # create readme with links to all solutions
# with open('README.md', 'w') as f:
#     f.write('# Personal LeetCode Solutions\n\n')
#     f.write('## Solutions\n\n')
#     for dir in dirs:
#         f.write(f'### {getPrettyLangName(dir)}\n\n')
#         f.write(f'| # | Title | Solution | Link |\n')
#         f.write(f'|---| ----- | -------- | ---- |\n')
#         problems = getProblemsFromDir(dir)
#         problems.sort()
#         print(f'{problem} | [{problem}](./{dir}/{problem}) | [Solution](./{dir}/{problem}) | [Link](https://leetcode.com/problems/{kebab(problem)})')
#         for problem in problems:
#             f.write(f'| {problem} | [{problem}](./{dir}/{problem}) | [Solution](./{dir}/{problem}) | [Link](https://leetcode.com/problems/{kebab(problem)}) |\n')
#         f.write('\n')

