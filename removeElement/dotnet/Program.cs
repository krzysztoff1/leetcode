namespace RemoveElement
{
    public class TestCase
    {
        public int[] Nums { get; set; }
        public int Val { get; set; }
        public int Expected { get; set; }

        public TestCase(int[] nums, int val, int expected)
        {
            Nums = nums;
            Val = val;
            Expected = expected;
        }
    }

    public class CustomComparer : IComparer<int>
    {
        public static int Compare(int x, int y, int val)
        {
            if (x == val)
            {
                return 1;
            }

            if (y == val)
            {
                return -1;
            }

            return 0;
        }

        public int Compare(int x, int y)
        {
            return Compare(x, y, 0);
        }
    }

    class Test
    {
        public static int RemoveElement(int[] nums, int val)
        {
            if (!nums.Contains(val))
            {
                return nums.Length;
            }

            CustomComparer comparer = new();

            Array.Sort(nums, (int x, int y) => CustomComparer.Compare(x, y, val));

            return Array.FindIndex(nums, (int x) => x == val);
        }

        public static void Main()
        {
            var testCases = new List<TestCase>
            {
            new(new int[] {3, 2, 2, 3}, 3, 2),
            new(new int[] {0, 1, 2, 2, 3, 0, 4, 2}, 2, 5),
            new(new int[] {2}, 3, 1),
            };

            foreach (var testCase in testCases)
            {
                int result = Test.RemoveElement(testCase.Nums, testCase.Val);

                Console.WriteLine($"nums: {String.Join(",", testCase.Nums)}");
                Console.WriteLine($"val: {testCase.Val}");
                Console.WriteLine($"expected: {testCase.Expected}");
                Console.WriteLine($"result: {result}");
                Console.WriteLine($"pass: {testCase.Expected == result}");
                Console.WriteLine();
            }
        }
    }
}

