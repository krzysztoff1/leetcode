class Solution(object):
    def kidsWithCandies(self, candies, extraCandies):
        maxCandies = max(candies)
        returnArray = []

        for candy in candies:
            returnArray.append(candy + extraCandies >= maxCandies)

        return returnArray


print(Solution().kidsWithCandies([2, 3, 5, 1, 3], 3))
