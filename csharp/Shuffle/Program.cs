// input: nums = [2, 5, 1, 3, 4, 7], n = 3
// output: [2, 3, 5, 4, 1, 7] 
// explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].

int[] Shuffle(int[] nums, int n)
{
    int[] firstArray = new int[n];
    int[] secondArray = new int[n];

    for (int i = 0; i < 2 * n; i++)
    {
        if (i < n)
        {
            firstArray[i] = nums[i];
        }
        else
        {
            secondArray[i - n] = nums[i];
        }
    }

    int[] output = new int[2 * n];

    int j = 0;
    int k = 0;

    for (int i = 0; i < 2 * n; i++)
    {
        if (i % 2 == 0)
        {
            output[i] = firstArray[j];
            j = (j + 1) >= n ? 0 : j + 1;
        }
        else
        {
            output[i] = secondArray[k];
            k = (k + 1) >= n ? 0 : k + 1;
        }
    }

    return output;
}

Console.WriteLine($"{string.Join(", ", Shuffle(new int[6] { 2, 5, 1, 3, 4, 7 }, 3))} expected [2,3,5,4,1,7]");
