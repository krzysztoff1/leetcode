// Input: digits = [4,3,2,1]
// Output: [4,3,2,2]
// Explanation: The array represents the integer 4321.
// Incrementing by one gives 4321 + 1 = 4322.
// Thus, the result should be [4,3,2,2].

int[] PlusOne(int[] digits)
{
    int[] IncreaseAtIndex(int[] digits, int index)
    {
        if (index == -1)
        {
            int[] newArray = new int[digits.Length + 1];
            newArray[0] = 1;
            newArray[1] = 0;

            for (int i = 0; i < digits.Length - 1; i++)
            {
                newArray[i] = digits[i] + (i == 0 ? 1 : 0);
            }

            return newArray;
        }

        if (digits[index] == 9)
        {
            digits[index] = 0;
            return IncreaseAtIndex(digits, index - 1);
        }

        digits[index] = digits[index] + 1;

        return digits;
    }

    int[] arr = IncreaseAtIndex(digits, digits.Length - 1);

    string output = "";
    for (int i = 0; i < arr.Length; i++)
    {
        output += arr[i];
    }

    char[] chars = output.ToString().ToCharArray();
    int[] res = new int[chars.Length];

    for (int i = 0; i < chars.Length; i++)
    {
        res[i] = int.Parse(chars[i].ToString());
    }

    return res;
}

// int[] input = new int[] { 1,2,3,8,8,6,9,6,6,9,9 };
// int[] input = new int[] { 6,1,4,5,3,9,0,1,9,5,1,8,6,7,0,5,5,4,3 };
// int[] input = new int[] { 0 };
// int[] input = new int[] { 9, 9 };
// int[] input = new int[] { 9 };
// int[] input = new int[] { 1,2,3 };
int[] input = new int[] { 7, 2, 8, 5, 0, 9, 1, 2, 9, 5, 3, 6, 6, 7, 3, 2, 8, 4, 3, 7, 9, 5, 7, 7, 4, 7, 4, 9, 4, 7, 0, 1, 1, 1, 7, 4, 9, 9, 9 };

Console.WriteLine($"Output: {string.Join(", ", PlusOne(input))}");
