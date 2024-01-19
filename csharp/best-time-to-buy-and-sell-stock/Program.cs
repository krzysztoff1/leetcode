int MaxProfit(int[] prices)
{
    int profit = 0;
    int min = prices[0];

    for (int i = 0; i < prices.Length; i++)
    {
        if (prices[i] < min)
        {
            min = prices[i];
            continue;
        }

        int thisProfit = prices[i] - min;
        if (thisProfit > profit)
        {
            profit = thisProfit;
        }
    }

    return profit;
}

Console.WriteLine($"actual: {MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 })}, expected: 5");
Console.WriteLine($"actual: {MaxProfit(new int[] { 7, 6, 4, 3, 1 })}, expected: 0");
Console.WriteLine($"actual: {MaxProfit(new int[] { 2, 4, 1 })}, expected: 2");
Console.WriteLine($"actual: {MaxProfit(new int[] { 2, 1, 2, 1, 0, 1, 2 })}, expected: 2");
