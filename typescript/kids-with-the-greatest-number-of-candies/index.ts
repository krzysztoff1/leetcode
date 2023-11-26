function kidsWithCandies(candies: number[], extraCandies: number): boolean[] {
  return candies.map(
    (numOfCandies) => Math.max(...candies) <= numOfCandies + extraCandies
  );
}

console.log(
  kidsWithCandies([2, 3, 5, 1, 3], 3).toString() ===
    [true, true, true, false, true].toString()
);
console.log(
  kidsWithCandies([4, 2, 1, 1, 2], 1).toString() ===
    [true, false, false, false, false].toString()
);
console.log(
  kidsWithCandies([12, 1, 12], 10).toString() === [true, false, true].toString()
);
