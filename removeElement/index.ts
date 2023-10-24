function removeElement(nums: number[], val: number): number {
  return nums.includes(val)
    ? nums.sort((num) => (num === val ? 1 : -1)).indexOf(val)
    : nums.length;
}

const nums = [3, 2, 2, 3];
const val = 3;
const expected = [2, 2].length;

console.table({
  nums: String(nums),
  val,
  expected,
  result: removeElement(nums, val),
  pass: expected === removeElement(nums, val),
});

const nums2 = [0, 1, 2, 2, 3, 0, 4, 2];
const val2 = 2;
const expected2 = [0, 1, 4, 0, 3].length;

console.table({
  nums2: String(nums2),
  val2,
  expected2,
  result: removeElement(nums2, val2),
  pass: expected2 === removeElement(nums2, val2),
});

const num3 = [2];
const val3 = 3;
const expected3 = [2].length;

console.table({
  num3: String(num3),
  val3,
  expected3,
  result: removeElement(num3, val3),
  pass: expected3 === removeElement(num3, val3),
});
