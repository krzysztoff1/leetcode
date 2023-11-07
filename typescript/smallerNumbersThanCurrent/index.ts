function smallerNumbersThanCurrent(nums: number[]): number[] {
  const sortedNums = [...nums].sort((a, b) => a - b);
  const acc: number[] = [];

  for (const num of nums) {
    acc.push(sortedNums.indexOf(num));
  }

  return acc;
}

console.log(
  smallerNumbersThanCurrent([8, 1, 2, 2, 3]).toString() ===
    [4, 0, 1, 1, 3].toString()
);
console.log(
  smallerNumbersThanCurrent([6, 5, 4, 8]).toString() === [2, 1, 0, 3].toString()
);
console.log(
  smallerNumbersThanCurrent([7, 7, 7, 7]).toString() === [0, 0, 0, 0].toString()
);
console.log(
  smallerNumbersThanCurrent([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]).toString() ===
    [0, 1, 2, 3, 4, 5, 6, 7, 8, 9].toString()
);
