bool IsPalindrome(int x) {
    if (x < 0) {
        return false;
    }

    char[] chars = x.ToString().ToCharArray();

    if (string.Join("", chars) == string.Join("", chars.Reverse()))
    {
        return true;
    }

    return false;
}

Console.WriteLine($"Expected: true, Actual: {IsPalindrome(121)}");
Console.WriteLine($"Expected: false, Actual: {IsPalindrome(-121)}");
Console.WriteLine($"Expected: false, Actual: {IsPalindrome(10)}");
Console.WriteLine($"Expected: false, Actual: {IsPalindrome(-101)}");
Console.WriteLine($"Expected: true, Actual: {IsPalindrome(0)}");
Console.WriteLine($"Expected: false, Actual: {IsPalindrome(1000021)}");
Console.WriteLine($"Expected: true, Actual: {IsPalindrome(12000021)}");
