using System;

namespace SamplePractice
{
    internal static class Tester
    {
        /// <summary>
        /// Runs all the tests for the GenerateUrgent method.
        /// </summary>
        public static void RunTests()
        {
            Console.WriteLine("Starting tests...");

            // List of tests
            int failedTests = 0;
            int passedTests = 0;

            // Tests for GenerateUrgent
            if (TestGenerateUrgent(CreateCallList(new (Customer, int)[]
            {
                (new Customer("Alice", 6), 200),
                (new Customer("Bob", 2), 100),
                (new Customer("Charlie", 10), 50)
            }), new (Customer, int)[] {
                (new Customer("Alice", 6), 200),
                (new Customer("Charlie", 10), 50)
            }) == 0)
            {
                passedTests++;
            }
            else
            {
                failedTests++;
            }

            if (TestGenerateUrgent(CreateCallList(new (Customer, int)[]
     {
                (new Customer("Alice", 6), 200),
                (new Customer("Bob", 2), 100),
                (new Customer("Charlie", 10), 50),
                (new Customer("Guy", 10), 500)
     }), new (Customer, int)[] {
                (new Customer("Alice", 6), 200),
                (new Customer("Charlie", 10), 50),
                (new Customer("Guy", 10), 500)
     }) == 0)
            {
                passedTests++;
            }
            else
            {
                failedTests++;
            }

            // Test for empty list
            if (TestGenerateUrgent(CreateCallList(new (Customer, int)[] { }), new (Customer, int)[] { }) == 0)
            {
                passedTests++;
            }
            else
            {
                failedTests++;
            }

            // Test for list of three calls returning an empty list
            if (TestGenerateUrgent(CreateCallList(new (Customer, int)[] {
                (new Customer("Alice", 2), 50),
                (new Customer("Bob", 3), 40),
                (new Customer("Charlie", 1), 30)
            }), new (Customer, int)[] { }) == 0)
            {
                passedTests++;
            }
            else
            {
                failedTests++;
            }

            // Summary output
            Console.WriteLine($"Number of passed tests: {passedTests}");
            if (failedTests == 0)
            {
                Console.WriteLine("All tests passed successfully!");
            }
            else
            {
                Console.WriteLine($"Number of failed tests: {failedTests}");
            }
        }

        /// <summary>
        /// Tests the GenerateUrgent method.
        /// </summary>
        private static int TestGenerateUrgent(Node<Call> callList, (Customer, int)[] expected)
        {
            Node<Call> result = Program.GenerateUrgent(callList, 150);

            var expectedList = CreateCallList(expected);
            if (CompareCallLists(result, expectedList))
            {
                Console.WriteLine("Test passed: GenerateUrgent");
                return 0; // Test passed
            }
            else
            {
                Console.WriteLine("Test failed: GenerateUrgent returned unexpected result");
                Console.WriteLine("Expected:");
                PrintCallList(expectedList);
                Console.WriteLine("Actual:");
                PrintCallList(result);
                return 1; // Test failed
            }
        }

        /// <summary>
        /// Creates a linked list of Call nodes.
        /// </summary>
        private static Node<Call> CreateCallList((Customer, int)[] calls)
        {
            Node<Call> head = null;
            Node<Call> current = null;

            foreach (var (customer, seconds) in calls)
            {
                Call call = new Call(customer, seconds);
                Node<Call> newNode = new Node<Call>(call);

                if (head == null)
                {
                    head = newNode;
                    current = head;
                }
                else
                {
                    current.SetNext(newNode);
                    current = current.GetNext();
                }
            }

            return head;
        }

        /// <summary>
        /// Prints a linked list of calls.
        /// </summary>
        private static void PrintCallList(Node<Call> list)
        {
            if (list == null)
            {
                Console.WriteLine("[Empty list]");
                return;
            }

            Console.Write("[");
            while (list != null)
            {
                Call call = list.GetValue();
                Console.Write($"(Customer: {call.GetCustomer().GetName()}, Seconds: {call.GetSeconds()})");

                list = list.GetNext();
                if (list != null)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }

        /// <summary>
        /// Compares two call linked lists for equality.
        /// </summary>
        private static bool CompareCallLists(Node<Call> list1, Node<Call> list2)
        {
            PrintCallList(list1);
            PrintCallList(list2);
            while (list1 != null && list2 != null)
            {
                Call call1 = list1.GetValue();
                Call call2 = list2.GetValue();

                if (!call1.GetCustomer().Equals(call2.GetCustomer()) || call1.GetSeconds() != call2.GetSeconds())
                {
                    return false;
                }

                list1 = list1.GetNext();
                list2 = list2.GetNext();
            }

            bool isEqual = list1 == null && list2 == null;
            Console.WriteLine($"Comparison result: {isEqual}");
            return isEqual;
        }
    }
}
