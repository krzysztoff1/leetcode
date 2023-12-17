function searchInsert(nums: number[], target: number): number {
  if (nums.includes(target)) {
    return nums.indexOf(target);
  }

  let closestNum = nums[0];
  let diff = Math.abs(target - closestNum);

  for (var val = 0; val < nums.length; val++) {
    const newdiff = Math.abs(target - nums[val]);

    if (newdiff < diff) {
      diff = newdiff;
      closestNum = nums[val];
    }
  }

  const indexOfClosestNum = nums.indexOf(closestNum);

  return closestNum < target ? indexOfClosestNum + 1 : indexOfClosestNum;
}

console.log(searchInsert([1, 3, 5, 6], 2) === 1);
console.log(searchInsert([1, 3, 5, 6], 3) === 1);
console.log(searchInsert([1, 3, 5, 6], 7) === 4);
console.log(searchInsert([1, 3, 5, 6], 2) === 1);
console.log(searchInsert([1], 0) === 0);
