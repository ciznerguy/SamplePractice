// Assuming Node<T> is used to represent a linked list,
// Let's implement the solutions for GenerateUrgent and MaxVIPWait.

// Class to represent Customer

using System;

namespace SamplePractice
{
    public class Customer
    {
        private string name;
        private int yearsAsMember;

        public Customer(string name, int yearsAsMember)
        {
            this.name = name;
            this.yearsAsMember = yearsAsMember;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetYearsAsMember()
        {
            return yearsAsMember;
        }

        public void SetYearsAsMember(int years)
        {
            this.yearsAsMember = years;
        }

        public bool IsVIP()
        {
            return yearsAsMember > 5;
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer other)
            {
                return this.name == other.name && this.yearsAsMember == other.yearsAsMember;
            }
            return false;
        }



        public override string ToString()
        {
            return $"Name: {name}, YearsAsMember: {yearsAsMember}";
        }
    }

    // Class to represent Call
    public class Call
    {
        private Customer customer;
        private int seconds;

        public Call(Customer customer, int seconds)
        {
            this.customer = customer;
            this.seconds = seconds;
        }

        public Call(Call other)
        {
            this.customer = new Customer(other.customer.GetName(), other.customer.GetYearsAsMember());
            this.seconds = other.seconds;
        }

        public Customer GetCustomer()
        {
            return customer;
        }

        public void SetCustomer(Customer customer)
        {
            this.customer = customer;
        }

        public int GetSeconds()
        {
            return seconds;
        }

        public void SetSeconds(int seconds)
        {
            this.seconds = seconds;
        }

        public override string ToString()
        {
            return $"Customer: {customer}, Seconds: {seconds}";
        }
    }

    // Class to implement CallCenter functionality
    public class CallCenter
    {
        private Node<Call> callList;

        public CallCenter(Node<Call> callList)
        {
            this.callList = callList;
        }

        public Node<Call> GetCallList()
        {
            return callList;
        }

        public void SetCallList(Node<Call> callList)
        {
            this.callList = callList;
        }

        public static Node<Call> GenerateUrgent(Node<Call> callList, int threshold)
        {
            Node<Call> urgentHead = null;
            Node<Call> pos = null;

            Node<Call> current = callList;
            while (current != null)
            {
                Call call = current.GetValue();
                if (call.GetSeconds() > threshold || call.GetCustomer().IsVIP())
                {
                    Call newCall = new Call(call.GetCustomer(), call.GetSeconds()); // יצירת עותק
                    Node<Call> newNode = new Node<Call>(newCall);

                    if (urgentHead == null)
                    {
                        urgentHead = newNode;
                        pos = newNode;
                    }
                    else
                    {
                        pos.SetNext(newNode);
                        pos = newNode;
                    }
                }

                current = current.GetNext();
            }

            return urgentHead;
        }
    }
}
