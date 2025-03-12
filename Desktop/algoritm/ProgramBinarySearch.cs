﻿using System;

namespace BinarySearch
{
    class Program
    {
        static void Main()
        {
            int[] numbers = ReadNumbers();
            int numberToFind = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(BinarySearch(numbers, numberToFind));
            Console.Read();
        }

        private static int[] ReadNumbers()
        {
            string[] numbers = Console.ReadLine().Split();
            int[] result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = Convert.ToInt32(numbers[i]);
            }

            return result;
        }

        static int BinarySearch(int[] numbers, int numberToFind)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (CheckNumberAtIndex(numbers, mid, numberToFind))
                {
                    return mid;
                }

                if (numbers[mid] < numberToFind)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        static bool CheckNumberAtIndex(int[] numbers, int index, int numberToCheck)
        {
            Console.WriteLine("Checking index " + index + " (value " + numbers[index] + ")");
            return numbers[index] == numberToCheck;
        }
    }
}
