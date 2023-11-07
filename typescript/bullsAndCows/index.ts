function getHint(secret: string, guess: string): string {
  const secretArray = secret.split("");
  const guessArray = guess.split("");
  const correctPositionAndNumber: string[] = new Array(secretArray.length).fill(
    ""
  );
  const correctNumber: string[] = new Array(secretArray.length).fill("");

  for (let i = 0; i < guessArray.length; i++) {
    if (secretArray[i] === guessArray[i]) {
      correctPositionAndNumber[i] = secretArray[i];
      secretArray[i] = "";
      guessArray[i] = "";
    }
  }

  for (let i = 0; i < guessArray.length; i++) {
    if (
      secretArray.includes(guessArray[i]) &&
      secretArray[i] !== guessArray[i]
    ) {
      const index = secretArray.indexOf(guessArray[i]);

      correctNumber[index] = secretArray[index];
      secretArray[index] = "";
    }
  }

  return `${correctPositionAndNumber.filter((x) => x).length}A${
    correctNumber.filter((x) => x).length
  }B`;
}

const testCases = [
  { secret: "1807", guess: "7810", expected: "1A3B" },
  { secret: "1123", guess: "0111", expected: "1A1B" },
  { secret: "1122", guess: "1222", expected: "3A0B" },
  { secret: "1122", guess: "2211", expected: "0A4B" },
  { secret: "1", guess: "0", expected: "0A0B" },
  { secret: "1", guess: "1", expected: "1A0B" },
  { secret: "11", guess: "10", expected: "1A0B" },
];

const result: {
  secret: string;
  guess: string;
  expected: string;
  actual: string;
  pass: boolean;
}[] = [];

testCases.forEach(({ secret, guess, expected }) => {
  const actual = getHint(secret, guess);
  const pass = actual === expected;

  result.push({ secret, guess, expected, actual, pass });
});

console.table(result);
