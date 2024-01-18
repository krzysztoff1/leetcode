bool IsStrictlyPalindromic(int n)
{
    for (int i = 2; i <= n - 2; i++)
    {
        string binary = "";
        int temp = i;
        while (temp > 0)
        {
            binary = (temp % 2) + binary;
            temp /= 2;
        }

        char[] chars = binary.ToCharArray();

        if (string.Join("", chars) == string.Join("", chars.Reverse()))
        {
            continue;
        }

        return false;
    }
    return true;
}

Console.WriteLine($"Case: 5, Expected: False, Actual: {IsStrictlyPalindromic(5)}");
