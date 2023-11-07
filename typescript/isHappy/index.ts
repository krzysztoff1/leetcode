function isHappy(n: number): boolean {
  const map = new Map();

  for (let i = 0; i < Number.MAX_SAFE_INTEGER; i++) {
    const sum = String(n)
      .split("")
      .map((n) => Number(n) * Number(n))
      .reduce((a, b) => a + b, 0);

    if (map.has(sum)) {
      return false;
    }

    if (sum === 1) {
      return true;
    }

    map.set(sum, true);
    n = sum;
  }

  return false;
}

console.log(isHappy(2) === false);
console.log(isHappy(19) === true);
console.log(isHappy(7) === true);
console.log(isHappy(1) === true);
console.log(isHappy(0) === false);
console.log(isHappy(11) === false);
console.log(isHappy(12) === false);
