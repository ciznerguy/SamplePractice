using System;

namespace SamplePractice
{
    internal static class Tester
    {
        /// <summary>
        /// Runs all the tests for the Average, sumOfArray, and SumOfList methods.
        /// </summary>
        public static void RunTests()
        {
            Console.WriteLine("Starting tests...");

            // List of tests
            int failedTests = 0;

            // Tests for Average
            failedTests += TestAverage(0, 6, 3);
            failedTests += TestAverage(10, 20, 15);
            failedTests += TestAverage(-5, 5, 0);
            failedTests += TestAverage(0, 0, 0);
            failedTests += TestAverage(7, 3, 5); // Additional example test

            // Tests for sumOfArray
            failedTests += TestSumOfArray(new int[] { 1, 2, 3, 4 }, 10);
            failedTests += TestSumOfArray(new int[] { 0, 0, 0 }, 0);
            failedTests += TestSumOfArray(new int[] { -1, -2, -3 }, -6);
            failedTests += TestSumOfArray(new int[] { 5 }, 5);
            failedTests += TestSumOfArray(new int[] { }, 0); // Edge case: empty array

            // Tests for SumOfList
            failedTests += TestSumOfList(CreateList(new int[] { 1, 2, 3, 4 }), 10);
            failedTests += TestSumOfList(CreateList(new int[] { 0, 0, 0 }), 0);
            failedTests += TestSumOfList(CreateList(new int[] { -1, -2, -3 }), -6);
            failedTests += TestSumOfList(CreateList(new int[] { 5 }), 5);
            failedTests += TestSumOfList(CreateList(new int[] { }), 0); // Edge case: empty list

            // Summary output
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
        /// Tests a single case of the Average method and returns 1 if the test fails.
        /// </summary>
        private static int TestAverage(int num1, int num2, double expected)
        {
            double result = Program.Average(num1, num2);
            if (result == expected)
            {
                Console.WriteLine($"Test passed: Average({num1}, {num2}) = {result}");
                return 0; // Test passed
            }
            else
            {
                Console.WriteLine($"Test failed: Average({num1}, {num2}) returned {result}, but expected {expected}");
                return 1; // Test failed
            }
        }

        /// <summary>
        /// Tests a single case of the sumOfArray method and returns 1 if the test fails.
        /// </summary>
        private static int TestSumOfArray(int[] array, int expected)
        {
            int result = Program.sumOfArray(array);
            if (result == expected)
            {
                Console.WriteLine($"Test passed: sumOfArray({string.Join(", ", array)}) = {result}");
                return 0; // Test passed
            }
            else
            {
                Console.WriteLine($"Test failed: sumOfArray({string.Join(", ", array)}) returned {result}, but expected {expected}");
                return 1; // Test failed
            }
        }

        /// <summary>
        /// Tests a single case of the SumOfList method and returns 1 if the test fails.
        /// </summary>
        private static int TestSumOfList(Node<int> list, int expected)
        {
            int result = Program.SumOfList(list);
            if (result == expected)
            {
                Console.WriteLine($"Test passed: SumOfList({ListToString(list)}) = {result}");
                return 0; // Test passed
            }
            else
            {
                Console.WriteLine($"Test failed: SumOfList({ListToString(list)}) returned {result}, but expected {expected}");
                return 1; // Test failed
            }
        }

        /// <summary>
        /// Converts an array to a linked list.
        /// </summary>
        private static Node<int> CreateList(int[] values)
        {
            Node<int> head = null;
            Node<int> current = null;

            foreach (int value in values)
            {
                if (head == null)
                {
                    head = new Node<int>(value);
                    current = head;
                }
                else
                {
                    current.SetNext(new Node<int>(value));
                    current = current.GetNext();
                }
            }

            return head;
        }

        /// <summary>
        /// Converts a linked list to a string representation.
        /// </summary>
        private static string ListToString(Node<int> list)
        {
            if (list == null)
            {
                return "[]";
            }

            var result = new System.Text.StringBuilder("[");
            while (list != null)
            {
                result.Append(list.GetValue());
                if (list.HasNext())
                {
                    result.Append(", ");
                }
                list = list.GetNext();
            }
            result.Append("]");
            return result.ToString();
        }
    }
}
