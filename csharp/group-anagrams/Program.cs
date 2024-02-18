IList<IList<string>> GroupAnagrams(string[] strs)
{
    IList<IList<char[]>> output = [];

    for (int i = 0; i < strs.Length; i++)
    {
        char[] chars = strs[i].ToCharArray();
        bool wasAdded = false;

        for (int j = 0; j < output.Count; j++)
        {
            char[] existingChars = output[j][0];
            bool isSame = chars.Length == existingChars.Length && Enumerable.SequenceEqual(chars.OrderBy(e => e), existingChars.OrderBy(e => e));

            if (isSame)
            {
                output[j].Add(chars);
                wasAdded = true;
            }
        }

        if (!wasAdded)
        {
            output.Add([chars]);
        }
    }

    IList<IList<string>> result = [];

    for (int i = 0; i < output.Count; i++)
    {
        result.Add(output[i].Select(x => string.Join("", x)).ToList());
    }

    return result;
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
