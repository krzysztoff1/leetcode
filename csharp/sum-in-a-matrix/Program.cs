/**
 * TODO Make this a looooooot faster 
 */

int MatrixSum(int[][] nums)
{
    int sum = 0;
    int[] largestNums = new int[nums.Length];

    do
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int maxValue = nums[i].Max();
            int maxIndex = nums[i].ToList().IndexOf(maxValue);

            largestNums[i] = maxValue;
            nums[i][maxIndex] = 0;
        }
        int sumInThisPass = largestNums.Max();
        sum += sumInThisPass;
    } while (largestNums.Max() != 0);

    return sum;
}

Console.WriteLine(MatrixSum(new int[][] {
    new int[] { 7, 2, 1 },
    new int[] { 6, 4, 2 },
    new int[] { 6, 5, 3 },
    new int[] { 3, 2, 1 }
})); // 15
