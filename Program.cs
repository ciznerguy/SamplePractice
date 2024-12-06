using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePractice
{
    internal class Program
    {



        public static Node<Call> GenerateUrgent(Node<Call> head, int threshold)
        {
            Node<Call> dummyHead = new Node<Call>(null), tail = dummyHead;
            Node<Call> current = head;

            while (current != null)
            {
                // Directly check the condition for urgency
                if (current.GetValue().GetSeconds() > threshold ||
                    current.GetValue().GetCustomer().IsVIP())
                {
                    // Create a duplicate call using the copying constructor
                    tail.SetNext(new Node<Call>(new Call(current.GetValue())));
                    tail = tail.GetNext();
                }
                current = current.GetNext();
            }

            return dummyHead.GetNext();
        }

        //public static Node<Call> GenerateUrgent(Node<Call> callList, int threshold)
        //{
        //    Node<Call> urgentHead = null;
        //    Node<Call> pos = null;

        //    Node<Call> current = callList;
        //    while (current != null)
        //    {
        //        Call call = current.GetValue();
        //        if (call.GetSeconds() > threshold || call.GetCustomer().IsVIP())
        //        {
        //            Call newCall = new Call(call.GetCustomer(), call.GetSeconds()); // יצירת עותק
        //            Node<Call> newNode = new Node<Call>(newCall);

        //            if (urgentHead == null)
        //            {
        //                urgentHead = newNode;
        //                pos = newNode;
        //            }
        //            else
        //            {
        //                pos.SetNext(newNode);
        //                pos = newNode;
        //            }
        //        }

        //        current = current.GetNext();
        //    }

        //    return urgentHead;
        //}

        // Solution for MaxVIPWait
        //public Customer MaxVIPWait()
        //{
        //    Node<Call> current = callList;
        //    Customer maxVIP = null;
        //    int maxWaitTime = -1;

        //    while (current != null)
        //    {
        //        Call call = current.GetValue();
        //        if (call.GetCustomer().IsVIP() && call.GetSeconds() > maxWaitTime)
        //        {
        //            maxVIP = call.GetCustomer();
        //            maxWaitTime = call.GetSeconds();
        //        }

        //        current = current.GetNext();
        //    }

        //    return maxVIP;
        //}
        static void Main(string[] args)
        {
            Tester.RunTests();
        }
    }
}
