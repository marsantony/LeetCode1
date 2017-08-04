﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Longest_Palindromic_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string res = new Solution().LongestPalindrome("a");
            Console.ReadLine();
        }
    }

    //manachers-algorithm O(n)
    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new Exception("Empty String");

            int N = s.Length;
            N = 2 * N + 1; //Position count
            int[] L = new int[N]; //LPS Length Array
            L[0] = 0;
            L[1] = 1;
            int C = 1; //centerPosition 
            int R = 2; //centerRightPosition
            int i = 0; //currentRightPosition
            int iMirror; //currentLeftPosition
            int maxLPSLength = 1;
            int maxLPSCenterPosition = 0;
            int start = -1;
            int diff = -1;

            //Uncomment it to print LPS Length array
            //printf("%d %d ", L[0], L[1]);
            for (i = 2; i < N; i++)
            {
                //get currentLeftPosition iMirror for currentRightPosition i
                iMirror = 2 * C - i;
                L[i] = 0;
                diff = R - i;
                //If currentRightPosition i is within centerRightPosition R
                if (diff > 0)
                    L[i] = Math.Min(L[iMirror], diff);

                //Attempt to expand palindrome centered at currentRightPosition i
                //Here for odd positions, we compare characters and 
                //if match then increment LPS Length by ONE
                //If even position, we just increment LPS by ONE without 
                //any character comparison
                while (((i + L[i]) < N - 1 && (i - L[i]) > 0) &&
                    (((i + L[i] + 1) % 2 == 0) ||
                    (s[(i + L[i] + 1) / 2] == s[(i - L[i] - 1) / 2])))
                {
                    L[i]++;
                }


                if (L[i] > maxLPSLength)  // Track maxLPSLength
                {
                    maxLPSLength = L[i];
                    maxLPSCenterPosition = i;
                }

                //If palindrome centered at currentRightPosition i 
                //expand beyond centerRightPosition R,
                //adjust centerPosition C based on expanded palindrome.
                if (i + L[i] > R)
                {
                    C = i;
                    R = i + L[i];
                }
            }
            start = (maxLPSCenterPosition - maxLPSLength) / 2;
            return s.Substring(start, maxLPSLength);

        }
    }

    //DP 解法 O(n^2)
    public class DPSolution
    {
        bool[,] dp;
        public string LongestPalindrome(string s)
        {
            if (s.Length == 0)
            {
                return "";
            }
            if (s.Length == 1)
            {
                return s;
            }

            dp = new bool[s.Length, s.Length];

            int i, j;

            for (i = 0; i < s.Length; i++)
            {
                for (j = 0; j < s.Length; j++)
                {
                    if (i >= j)
                    {
                        dp[i,j] = true; //当i == j 的时候，只有一个字符的字符串; 当 i > j 认为是空串，也是回文  

                    }
                    else
                    {
                        dp[i,j] = false; //其他情况都初始化成不是回文  
                    }
                }
            }

            int k;
            int maxLen = 1;
            int rf = 0, rt = 0;
            for (k = 1; k < s.Length; k++)
            {
                for (i = 0; k + i < s.Length; i++)
                {
                    j = i + k;
                    if (s[i] != s[j]) //对字符串 s[i....j] 如果 s[i] != s[j] 那么不是回文  
                    {
                        dp[i,j] = false;
                    }
                    else  //如果s[i] == s[j] 回文性质由 s[i+1][j-1] 决定  
                    {
                        dp[i,j] = dp[i + 1,j - 1];
                        if (dp[i,j])
                        {
                            if (k + 1 > maxLen)
                            {
                                maxLen = k + 1;
                                rf = i;
                                rt = j;
                            }
                        }
                    }
                }
            }
            return s.Substring(rf, rt + 1);
        }
    }
}
