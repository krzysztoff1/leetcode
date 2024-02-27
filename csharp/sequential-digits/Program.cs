IList<int> SequentialDigits(int low, int high)
{
    IList<int> result = [];

    string numbers = "123456789";



    for (int i = 0; i < numbers.Length; i++)
    {
        for (int j = 0; j < numbers.Length; j++)
        {
            int end = numbers.Length - j - i;

            if (end < 0)
            {
                continue;
            }


            string s = numbers.Substring(i, end);

            if (s == string.Empty)
            {
                continue;
            }


            int n = int.Parse(s);


            if (n > low && n < high)
            {
                result.Add(n);
            }
        }
    }


    return result;
}


void printList<T>(IList<T> list)
{
    Console.Write("[");
    for (int i = 0; i < list.Count; i++)
    {
        Console.Write(list[i]);
        if (i < list.Count - 1)
        {
            Console.Write(", ");
        }
    }
    Console.WriteLine("]");
}


Console.WriteLine($"SequentialDigits(1000, 13000)");
printList(SequentialDigits(1000, 13000));

