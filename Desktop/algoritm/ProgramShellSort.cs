using System;

namespace SortRandomNumbers
{
    class Program
    {
        static void Main()
        {
            int[] numbers = ReadNumbers();
            ShellSort(numbers);
            Print(numbers);
            Console.Read();
        }

        static void ShellSort(int[] numbers)
        {
            int i;
            int j;
            int temp;
            const int factorComun = 2;
            int increment = factorComun / 2;
            while (increment > 0)
            {
                for (i = 0; i < numbers.Length; i++)
                {
                    j = i;
                    temp = numbers[i];
                    while ((j >= increment) && (numbers[j - increment] > temp))
                    {
                        numbers[j] = numbers[j - increment];
                        j = j - increment;
                    }

                    numbers[j] = temp;
                }

                if (increment / factorComun != 0)
                {
                    increment = increment / factorComun;
                }
                else if (increment == 1)
                {
                    increment = 0;
                }
                else
                {
                    increment = 1;
                }
            }
        }

        static void Print(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.Write("\n");
        }

        static int[] ReadNumbers()
        {
            string[] numbers = Console.ReadLine().Split();
            int[] result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = Convert.ToInt32(numbers[i]);
            }

            return result;
        }
    }
}