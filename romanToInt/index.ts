const romans: [number, string][] = [
  [1000, "M"],
  [900, "CM"],
  [500, "D"],
  [400, "CD"],
  [100, "C"],
  [90, "XC"],
  [50, "L"],
  [40, "XL"],
  [10, "X"],
  [9, "IX"],
  [5, "V"],
  [4, "IV"],
  [3, "III"],
  [2, "II"],
  [1, "I"],
];

function romanToInt(s: string): number {
  if (!s) {
    return 0;
  }

  for (const [value, letter] of romans) {
    if (s.startsWith(letter)) {
      return value + romanToInt(s.slice(letter.length));
    }
  }

  return 0;
}

console.log(romanToInt("III")); // 3
console.log(romanToInt("IV")); // 4
console.log(romanToInt("IX")); // 9
console.log(romanToInt("LVIII")); // 58
console.log(romanToInt("MCMXCIV")); // 1994
