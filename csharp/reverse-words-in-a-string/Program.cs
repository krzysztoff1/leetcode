
string ReverseWords(string str)
{
    string[] arr = str.Trim().Split(" ");
    List<string> reversed = [];

    for (int i = arr.Length - 1; i >= 0; i--)
    {
        if (arr[i].Length == 0)
        {
            continue;
        }

        reversed.Add(arr[i]);
    }


    return string.Join(" ", [.. reversed]);
}


Console.WriteLine(ReverseWords("a good   example"));
