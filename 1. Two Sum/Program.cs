using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Two_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] res = new Solution().TwoSum(new int[] { 3, 3 }, 6);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] Result = new int[2];
            Dictionary<int, List<int>> NumbersIndexMap = new Dictionary<int, List<int>>();
            for (int NumIndex = 0; NumIndex < nums.Length; NumIndex++)
            {
                if (NumbersIndexMap.ContainsKey(nums[NumIndex]))
                    NumbersIndexMap[nums[NumIndex]].Add(NumIndex);
                else
                    NumbersIndexMap.Add(nums[NumIndex], new List<int>() { NumIndex });
            }

            foreach (int Num in NumbersIndexMap.Keys)
            {
                int OtherTarget = target - Num;

                if (NumbersIndexMap.ContainsKey(OtherTarget) && NumbersIndexMap[OtherTarget].Last() != NumbersIndexMap[Num].First())
                {
                    Result[0] = NumbersIndexMap[Num].First();
                    Result[1] = NumbersIndexMap[OtherTarget].Last();
                    break;
                }
            }

            return Result;
        }
    }
}
