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
            Dictionary<int, int> numbersIndexMap = new Dictionary<int, int>();
            for (int index = 0; index < nums.Length; index++)
            {
                int otherTarget = target - nums[index];
                if (numbersIndexMap.ContainsKey(otherTarget))
                    return new int[] { numbersIndexMap[otherTarget], index };

                numbersIndexMap.Add(nums[index], index);
            }
            throw new ArgumentOutOfRangeException("No two sum solution");
        }
    }
}
