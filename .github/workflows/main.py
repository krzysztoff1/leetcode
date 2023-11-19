import os

total_solutions = 0

for root, dirs, files in os.walk('.'):
    if root.count(os.sep) == 1:
        total_solutions += len(files)

print(f"Total LeetCode Solutions: {total_solutions}")