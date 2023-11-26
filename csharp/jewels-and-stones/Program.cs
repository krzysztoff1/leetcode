public class Solution
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        char[] jewelsArray = jewels.ToCharArray();
        char[] stonesArray = stones.ToCharArray();

        int output = 0;
        for (int i = 0; i < stonesArray.Length; i++)
        {
            if (jewelsArray.Contains(stonesArray[i]))
            {
                output++;
            }
        }
        return output;
    }
}