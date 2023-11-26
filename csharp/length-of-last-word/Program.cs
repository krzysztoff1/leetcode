public class Solution
{
    public int LengthOfLastWord(string s)
    {
        string[] stringArray = s.TrimEnd().Split(" ");
        return stringArray[^1].Length;
    }
}