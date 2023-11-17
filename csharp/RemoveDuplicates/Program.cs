// Input: nums = [1,1,2]
// Output: 2, nums = [1,2,_]
// Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
// It does not matter what you leave beyond the returned k (hence they are underscores).

int RemoveDuplicates(int[] nums)
{
    List<int> sortedNumbers = new List<int>();

    for (int i = 0; i < nums.Length; i++)
    {
        if (!sortedNumbers.Contains(nums[i]))
        {
            sortedNumbers.Add(nums[i]);
        }
    }

    for (int i = 0; i < nums.Length; i++)
    {
        if (i < sortedNumbers.Count)
            nums[i] = sortedNumbers[i];
    }

    return sortedNumbers.Count;
}

int[] input = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

Console.WriteLine($"Output: {RemoveDuplicates(input)}");