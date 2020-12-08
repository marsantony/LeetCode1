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

            ListNode res = new Solution().AddTwoNumbers(
                new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))),
                new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))
               );
            Console.ReadLine();
        }
    }

    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode();
            ListNode node1 = l1, node2 = l2, curr = result;
            int carry = 0, currVal = 0;
            while (node1 != null || node2 != null)
            {
                currVal = carry + (node1?.val ?? 0) + (node2?.val ?? 0);
                carry = currVal / 10;
                curr.next = new ListNode(currVal % 10);

                node1 = node1?.next;
                node2 = node2?.next;
                curr = curr.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }

            return result.next;
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
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}
