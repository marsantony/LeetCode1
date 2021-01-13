using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Median_of_Two_Sorted_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            double res = new BestSolution().FindMedianSortedArrays(new int[] { 1,3 }, new int[] { 2 });
            Console.ReadLine();
        }

    }
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double medianIndex = (double)(nums1.Length + nums2.Length - 1) / 2;
            List<double> medians = new List<double>(2);
            int[] medianIndexs = new int[2] { (int)Math.Floor(medianIndex), (int)Math.Ceiling(medianIndex) };
            int num1Index = 0, num2Index = 0, currNum = 0;
            for(int index = 0; index <= medianIndexs[1]; index++)
            {
                if (num1Index == nums1.Length || (num2Index != nums2.Length && nums1[num1Index] > nums2[num2Index]))
                {
                    currNum = nums2[num2Index];
                    num2Index += 1;
                }
                else
                {
                    currNum = nums1[num1Index];
                    num1Index += 1;
                }

                if (medianIndexs.Contains(index))
                {
                    medians.Add(currNum);
                }
            }

            return medians.Count == 1 ? medians[0] : (medians[0] + medians[1]) / 2;

            //bool LongerArrayNums2 = nums1.Length <= nums2.Length;
            //int[] A = nums1, B = nums2;
            //int m = nums1.Length, n = nums2.Length;
            //if (!LongerArrayNums2)
            //{
            //    A = nums2;
            //    B = nums1;
            //    m = nums2.Length;
            //    n = nums1.Length;
            //}

            //if (n == 0)
            //    throw new Exception("Two Empty Array");

            //int iMin = 0, iMax = m, HalfLen = (m + n + 1) / 2,
            //    i = (iMin + iMax) / 2, j = HalfLen - i;
            //double MaxOfLeft = 0, MinOfRight = 0;

            //while (iMin <= iMax)
            //{
            //    i = (iMin + iMax) / 2;
            //    j = HalfLen - i;

            //    if (i < m && B[j - 1] > A[i])
            //    {
            //        iMin = i + 1;
            //    }
            //    else if (i > 0 && A[i - 1] > B[j])
            //    {
            //        iMax = i - 1;
            //    }else
            //    {
            //        if (i == 0)
            //            MaxOfLeft = B[j - 1];
            //        else if (j == 0)
            //            MaxOfLeft = A[i - 1];
            //        else
            //            MaxOfLeft = Math.Max(A[i - 1], B[j - 1]);

            //        if ((m + n) % 2 == 1)
            //            return MaxOfLeft;

            //        if (i == m)
            //            MinOfRight = B[j];
            //        else if (j == n)
            //            MinOfRight = A[i];
            //        else
            //            MinOfRight = Math.Min(A[i], B[j]);

            //        return (MaxOfLeft + MinOfRight) / 2;
            //    }
            //}

            //throw new Exception("Unexpected Error");
        }
    }

    public class BestSolution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            bool longerNums1 = nums1.Length >= nums2.Length;    //need n >= m
            int[] A, B;
            A = longerNums1 ? nums2 : nums1;
            B = longerNums1 ? nums1 : nums2;
            int m = A.Length, n = B.Length;

            if (n == 0)
                throw new Exception("Two Empty Array");

            int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2, i, j
                , maxOfLeft = 0, minOfRight = 0;

            while (iMin <= iMax)
            {
                i = (iMin + iMax) / 2;
                j = halfLen - i;
                if (i < m && B[j - 1] > A[i])
                {
                    iMin = i + 1;
                }
                else if(i > 0 && A[i-1] > B[j])
                {
                    iMax = i - 1;
                }
                else
                {
                    if (i == 0)
                        maxOfLeft = B[j - 1];
                    else if (j == 0)
                        maxOfLeft = A[i - 1];
                    else
                        maxOfLeft = Math.Max(B[j - 1], A[i - 1]);

                    if ((m + n) % 2 == 1)
                        return maxOfLeft;

                    if (i == m)
                        minOfRight = B[j];
                    else if (j == n)
                        minOfRight = A[i];
                    else
                        minOfRight = Math.Min(B[j], A[i]);

                    return (maxOfLeft + minOfRight) / 2.0;
                }
            }

            throw new Exception("Unexpected Error");
        }
    }

    /* 以為兩邊一直取中位數就可以逐漸逼近整個數列的中位數到直接取得，但偶數列的兩個中位數有可能都在同一數列，而這樣切會切成1+2，卻沒辦法判斷誰才是那兩個中位數
     * 之後試著以 https://discuss.leetcode.com/topic/4996/share-my-o-log-min-m-n-solution-with-explanation/2 的參考處理
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int nums1Length = nums1.Length, nums2Length = nums2.Length;
            int StartIndex1 = 0, StartIndex2 = 0, EndIndex1 = nums1Length-1, EndIndex2 = nums2Length - 1;
            int CurrentIndex1 = (EndIndex1 + StartIndex1) / 2, CurrentIndex2 = (EndIndex2 + StartIndex2) / 2;
            int CurrentNum1Median = 0, CurrentNum2Median = 0;
            bool IsEven = (nums1Length + nums2Length) % 2 == 0;
            int MedCapicity= (nums1Length + nums2Length - 1) / 2;
            if (nums1Length == 0)
                return (double)(nums2[CurrentIndex2] + nums2[CurrentIndex2 + (EndIndex2 + StartIndex2) % 2]) / 2;
            if (nums2Length == 0)
                return (double)(nums1[CurrentIndex1] + nums1[CurrentIndex1 + (EndIndex1 + StartIndex1) % 2]) / 2;

            //while ((IsEven && (EndIndex1 - StartIndex1 + EndIndex2 - StartIndex2) != 0) || (!IsEven && (EndIndex1 - StartIndex1 + EndIndex2 - StartIndex2) != 1))
            while (MedCapicity != (StartIndex1 + StartIndex2) || (MedCapicity != nums1Length - 1 - EndIndex1 + nums2Length - 1 - EndIndex2))
            {
                CurrentNum1Median = nums1[CurrentIndex1] + nums1[CurrentIndex1 + (EndIndex1 + StartIndex1) % 2];
                CurrentNum2Median = nums2[CurrentIndex2] + nums2[CurrentIndex2 + (EndIndex2 + StartIndex2) % 2];

                if (CurrentNum1Median == CurrentNum2Median)
                    return (double)CurrentNum1Median / 2;
                else if (CurrentNum1Median > CurrentNum2Median)
                {
                    EndIndex1 = CurrentIndex1;
                    StartIndex2 = CurrentIndex2 + (EndIndex2 + StartIndex2) % 2;
                }
                else
                {
                    EndIndex2 = CurrentIndex2;
                    StartIndex1 = CurrentIndex1 + (EndIndex1 + StartIndex1) % 2;
                }

                CurrentIndex1 = (EndIndex1 + StartIndex1) / 2;
                CurrentIndex2 = (EndIndex2 + StartIndex2) / 2;
            }

            

            
            return IsEven 
                    ? (double)(nums1[StartIndex1] + nums2[StartIndex2]) / 2 
                    : nums1[StartIndex1] == nums1[EndIndex1] ? Math.Min(Math.Max(nums1[StartIndex1], nums2[StartIndex2]), Math.Max(nums2[StartIndex2], nums2[EndIndex2])) 
                                                             : Math.Min(Math.Max(nums1[StartIndex1], nums1[EndIndex1]), Math.Max(nums1[StartIndex1], nums2[StartIndex2]));
            ;
        }
    }

    */
}
