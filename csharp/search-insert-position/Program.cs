
public class TestCase
{
    public required int[] Nums;
    public required int Target;
    public required int Expected;
}

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] >= target)
            {
                return i;
            }
        }

        return nums.Length;
    }

    public static void Main()
    {
        List<TestCase> testCases = new List<TestCase>
        {
            new() { Nums = [1, 3, 5, 6], Target = 5, Expected = 2 },
            new() { Nums = [1, 3, 5, 6], Target = 2, Expected = 1 },
            new() { Nums = [1, 3, 5, 6], Target = 7, Expected = 4 },
        };

        Solution solution = new();

        int i = 1;

        foreach (TestCase testCase in testCases)
        {
            Console.WriteLine($"Case: {i++}");
            Console.WriteLine($"Input: nums = [{string.Join(",", testCase.Nums)}], target = {testCase.Target}");

            int result = solution.SearchInsert(testCase.Nums, testCase.Target);

            Console.WriteLine($"Output: {result}");
            Console.WriteLine($"Expected: {testCase.Expected}");
            Console.WriteLine(result == testCase.Expected ? "Passed" : "Failed");
            Console.WriteLine();
        }
    }
}
