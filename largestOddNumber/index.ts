function isOdd(n: number) {
  return Math.abs(n % 2) == 1;
}

function largestOddNumber(num: string): string {
  if (isOdd(Number(num))) {
    return num;
  }

  for (let i = num.length - 1; i >= 0; i--) {
    if (isOdd(Number(num[i]))) {
      return num.slice(0, i + 1);
    }
  }

  return "";
}

console.log(largestOddNumber("35427") === "35427");
console.log(largestOddNumber("35427") === "35427");
console.log(largestOddNumber("52") === "5");
console.log(largestOddNumber("4206") === "");
