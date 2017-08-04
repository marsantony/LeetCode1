using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Add_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListNode res = new Solution().AddTwoNumbers(new ListNode(2) { next = new ListNode(4) { next = new ListNode(3) } },
            //    new ListNode(5) { next = new ListNode(6) { next = new ListNode(4) } });

            //ListNode res = new Solution().AddTwoNumbers(new ListNode(0) ,
            //   new ListNode(0));

            ListNode res = new Solution().AddTwoNumbers(new ListNode(9),
               new ListNode(1) { next = new ListNode(9)
               {
                   next = new ListNode(9)
                   {
                       next = new ListNode(9)
                       {
                           next = new ListNode(9)
                           {
                               next = new ListNode(9)

                               {
                                   next = new ListNode(9)
                                   {
                                       next = new ListNode(9)
                                       {
                                           next = new ListNode(9)
                                           { next = new ListNode(9) }
                                       }
                                   }
                               }
                           }
                       }
                   }
               } });
            Console.ReadLine();
        }
    }

    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = p?.val ?? 0;
                int y = q?.val ?? 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                p = p?.next;
                q = q?.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
        }
    }

    /* 完全忘記大數法則 (超過特定位數的處理，不是單純用int或long就可以解決的，直接相加真的是昏了頭，Test Case就讓我爆炸)
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        long Num1 = GetListNodeNumber(l1);
        long Num2 = GetListNodeNumber(l2);
        long AddNum = Num1 + Num2;
        ListNode ResultListNode = new ListNode((int)(AddNum % 10));
        ListNode CurrentNode = ResultListNode;
        for (int DigitIndex =1; DigitIndex < AddNum.ToString().Length; DigitIndex++)
        {
            CurrentNode.next = new ListNode((int)(AddNum / (long)Math.Pow(10, DigitIndex) % 10));
            CurrentNode = CurrentNode.next;
        }

        return ResultListNode;
    }

    private long GetListNodeNumber(ListNode ln)
    {
        int Degree = 1;
        long Result = ln.val;
        ListNode CurrentNode = ln;
        while (CurrentNode.next != null)
        {
            CurrentNode = CurrentNode.next;
            Result += CurrentNode.val * (long)Math.Pow(10, Degree);
            Degree++;
        }
        return Result;
    }
}
*/
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
