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
            int indexL = 0;
            int result = 0;
            char currCh = char.MinValue;
            //字元的索引值，只存最接近當前索引(indexR)的
            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();
            for (int indexR = 0; indexR < s.Length; indexR++)
            {
                currCh = s[indexR];
                indexL = charIndexMap.ContainsKey(currCh)
                            //最近的重複字元往前一位或當前左索引(indexL)位置，比較靠近當前索引為準
                            ? Math.Max(charIndexMap[currCh] + 1, indexL)    
                            : indexL;
                //當前索引 - 左索引 + 1 => 長度
                result = Math.Max(result, indexR - indexL + 1);

                if (charIndexMap.ContainsKey(currCh))
                    charIndexMap[currCh] = indexR;
                else
                    charIndexMap.Add(currCh, indexR);
            }

            return result;
        }
    }
}
