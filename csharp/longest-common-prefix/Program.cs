string LongestCommonPrefix(string[] strs)
{
    int maxLenOfCommonPrefix = strs.Min(y => y.Length);
    string shortestWord = strs.FirstOrDefault(x => x.Length == maxLenOfCommonPrefix) ?? "";
    string output = shortestWord;


    while (true)
    {
        if (strs.All(s => s.StartsWith(output)))
        {
            return output;
        }

        output = output.Remove(output.Length - 1);
    }
}

Console.WriteLine(LongestCommonPrefix(["flower", "flow", "flight"]));
