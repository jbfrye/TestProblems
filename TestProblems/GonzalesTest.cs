using System;
using System.Collections.Generic;
using System.Text;

namespace TestProblems
{
    class GonzalesTest
    {
        static void ModifyList(LinkedList<char> input)
        {
            LinkedListNode<char> first = input.First.Next;
            LinkedListNode<char> last = input.Last;

            while (first != last)
            {
                char temp = first.Value;
                first.Value = last.Value;
                last.Value = temp;
                first = first.Next;
                last = last.Previous;
            }
        }

        static void PrintList(LinkedList<char> input)
        {
            foreach (char c in input)
            {
                Console.WriteLine(c);
            }
        }

        public static void Run()
        {
            char[] chars = { 'A', 'B', 'C', 'D', 'E', 'F' };
            LinkedList<char> input = new LinkedList<char>(chars);
            PrintList(input);
            ModifyList(input);
            Console.WriteLine();
            PrintList(input);
        }
    }
}
