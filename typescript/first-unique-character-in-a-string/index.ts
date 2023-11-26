function firstUniqChar(s: string): number {
  const array = s.split("");
  const notOverlapped = [...new Set(array)].filter(
    (value) => array.filter((v) => v === value).length === 1
  );

  if (notOverlapped.length === 0) {
    return -1;
  }

  return array.indexOf(notOverlapped[0]);
}

console.log(firstUniqChar("leetcode") === 0);
console.log(firstUniqChar("loveleetcode") === 2);
console.log(firstUniqChar("aabb") === -1);
