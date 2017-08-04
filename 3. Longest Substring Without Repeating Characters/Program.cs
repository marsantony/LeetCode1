using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Longest_Substring_Without_Repeating_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            int res = new Solution().LengthOfLongestSubstring("pwwkew");
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length, ans = 0;
            Dictionary<char, List<int>> map = new Dictionary<char, List<int>>();
            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    i = Math.Max(map[s[j]].Last(), i);
                }
                else
                {
                    map.Add(s[j], new List<int>());
                }
                ans = Math.Max(ans, j - i + 1);

                map[s[j]].Add(j + 1);
            }
            return ans;
        }
    }
}
