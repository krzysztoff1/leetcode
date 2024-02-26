
IList<IList<string>> GroupAnagrams(string[] strs)
{
    Dictionary<string, IList<string>> dict = [];

    for (int i = 0; i < strs.Length; i++)
    {
        char[] sortedChars = strs[i].ToCharArray();
        sortedChars = sortedChars.OrderBy(c => c).ToArray();
        string wordWithSortedChars = new(sortedChars);

        if (dict.ContainsKey(wordWithSortedChars))
        {
            dict[wordWithSortedChars].Add(strs[i]);

        }
        else
        {
            dict.Add(wordWithSortedChars, [strs[i]]);
        }

    }

    return [.. dict.Values];
}

Console.WriteLine("Input:");

string[] strs = ["hhhhu", "tttti", "tttit", "hhhuh", "hhuhh", "tittt"];

Console.WriteLine(String.Join(", ", strs));


IList<IList<string>> output = GroupAnagrams(strs);

Console.WriteLine("Output: ");

foreach (var group in output)
{
    Console.WriteLine();
    foreach (var strings in group)
    {
        Console.Write(strings + ", ");
    }
    Console.WriteLine();
}
