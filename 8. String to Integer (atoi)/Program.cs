using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.String_to_Integer__atoi_
{
    class Program
    {
        static void Main(string[] args)
        {
            int res = new Solution().MyAtoi("2147483648");
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            str = str.Trim();

            int sign = 1, start = 0;long result = 0;
            if(str[0] == '-')
            {
                sign = -1;
                start = 1;
            }
            else if(str[0] == '+')
            {
                sign = 1;
                start = 1;
            }


            for(int i = start; i < str.Length; i++)
            {
                if (!char.IsNumber(str[i]))
                    return Convert.ToInt32(result * sign);
                else
                {
                    result = result * 10 + (int)char.GetNumericValue(str[i]);

                    if (sign == 1 && result >= Int32.MaxValue)
                        return Int32.MaxValue;
                    else if (sign == -1 && (result * sign) <= Int32.MinValue)
                        return Int32.MinValue;
                }
            }

            return Convert.ToInt32(result * sign);
        }
    }
}
