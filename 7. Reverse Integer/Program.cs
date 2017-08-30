using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Reverse_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            int res = new Solution().Reverse(int.MaxValue);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int Reverse(int x)
        {
            int result = 0, currentNumber = 0;
            try
            {
                while(x != 0)
                {
                    currentNumber = x % 10;
                    x = x / 10;
                    result = checked(result * 10);
                    result += currentNumber;
                }
                return result;
            }
            catch (OverflowException)
            {
                return 0;
            }
        }
    }
}
