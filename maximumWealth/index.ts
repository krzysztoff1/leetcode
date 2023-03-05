function maximumWealth(accounts: number[][]): number {
  let max = -1;

  for (let account of accounts) {
    const sum = account.reduce((sum, value) => sum + value, 0);

    if (sum > max) {
      max = sum;
    }
  }

  return max;
}

console.log(
  maximumWealth([
    [1, 2, 3],
    [3, 2, 1],
  ]) === 6
);
console.log(
  maximumWealth([
    [1, 5],
    [7, 3],
    [3, 5],
  ]) === 10
);
console.log(
  maximumWealth([
    [2, 8, 7],
    [7, 1, 3],
    [1, 9, 5],
  ]) === 17
);
