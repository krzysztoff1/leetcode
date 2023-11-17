// Input: operations = ["--X","X++","X++"]
// Output: 1
// Explanation: The operations are performed as follows:
// Initially, X = 0.
// --X: X is decremented by 1, X =  0 - 1 = -1.
// X++: X is incremented by 1, X = -1 + 1 =  0.
// X++: X is incremented by 1, X =  0 + 1 =  1.

int FinalValueAfterOperations(string[] operations)
{
    int output = 0;

    foreach (string operation in operations)
    {
        if (operation == "X++" || operation == "++X")
        {
            output++;
        }
        else
        {
            output--;
        }
    }

    return output;
}


string[] input = new string[] { "--X", "X++", "X++" };

Console.WriteLine($"Output: {FinalValueAfterOperations(input)}");