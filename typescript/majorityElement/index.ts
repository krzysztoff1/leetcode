function majorityElement(nums: number[]) {
  const uniqueNums = [...new Set(nums)];

  const lengths = uniqueNums.map(
    (num) => nums.filter((_num) => _num === num).length
  );

  return uniqueNums[lengths.indexOf(Math.max(...lengths))];
}

console.log(majorityElement([3, 2, 3]) === 3);
console.log(majorityElement([2, 2, 1, 1, 1, 2, 2]) === 2);
console.log(majorityElement([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]) === 1);
