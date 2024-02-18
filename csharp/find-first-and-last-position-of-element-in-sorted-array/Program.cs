
public class TestCase
{
    public required int[] Nums;
    public required int Target;
    public required int[] Expected;
}

public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        bool exists = false;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[left] == target)
            {
                exists = true;
            }
            else
            {
                left++;
            }

            if (nums[right] == target)
            {
                exists = true;
            }
            else
            {
                right--;
            }
        }

        if (!exists)
        {
            return [-1, -1];
        }

        return [left, right];
    }

    public static void Main()
    {
        List<TestCase> testCases =
        [

            new() { Nums = [5,7,7,8,8,10], Target = 8, Expected = [3,4] },
            new() { Nums = [5,7,7,8,8,10], Target = 6, Expected = [-1,-1] },
            new() { Nums = [1,3], Target = 1, Expected = [0,0] },
        ];

        Solution solution = new();

        int i = 1;

        foreach (TestCase testCase in testCases)
        {
            Console.WriteLine($"Case: {i++}");
            Console.WriteLine($"Input: nums = [{string.Join(",", testCase.Nums)}], target = {testCase.Target}");

            int[] result = solution.SearchRange(testCase.Nums, testCase.Target);

            Console.WriteLine($"Output: {string.Join(",", result)}");
            Console.WriteLine($"Expected: {string.Join(",", testCase.Expected)}");
            Console.WriteLine((result[0] == testCase.Expected[0] && result[1] == testCase.Expected[1]) ? "Passed" : "Failed");
            Console.WriteLine();
        }
    }
}
