using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.ZigZag_Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            string res = new Solution().Convert("PAYPALISHIRING", 3);
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            s = s ?? "";
            if (numRows == 1)
                return s;

            StringBuilder sb = new StringBuilder();
            int k1 = 0, k2 = 0, j = 0;
           
            for (int i = 0; i < numRows; i++)
            {
                k1 = i;
                k2 = 2 * (numRows - i - 1);
                k2 = i == 0 || i == (numRows - 1) ? 0 : k2;
                j = 2 * (numRows - 1);
             
                while (k1 < s.Length)
                {
                    sb.Append(s[k1]);

                    if((k1 + k2) < s.Length && k2 != 0)
                        sb.Append(s[k1 + k2]);

                    k1 = k1 + j;
                   
                }
            }

            return sb.ToString();
        }
    }
}
