using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Palindrome_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            bool res = new Solution().IsPalindrome(12344321);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            int rev = 0;
            int t = x;
            while (x > 0)
            {
                rev *= 10;
                rev += x % 10;
                x /= 10;
            }

            return rev == t;
        }
    }
}
