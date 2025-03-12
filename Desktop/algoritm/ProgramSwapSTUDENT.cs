using System;

namespace SortByGrade
{
    struct Student
    {
        public string Name;
        public double Grade;

        public Student(string name, double grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
    }

    class Program
    {
        static void Main()
        {
            Student[] students = ReadStudents();
            QuickSort(students, 0, students.Length - 1);
            Print(students);
            Console.Read();
        }

        static void QuickSort(Student[] students, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int pivotIndex = Partition(students, low, high);

            QuickSort(students, low, pivotIndex - 1);
            QuickSort(students, pivotIndex + 1, high);
        }

        static int Partition(Student[] students, int low, int high)
        {
            double pivot = students[high].Grade;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (students[j].Grade > pivot)
                {
                    i++;
                    Swap(ref students[i], ref students[j]);
                }
            }

            Swap(ref students[i + 1], ref students[high]);
            return i + 1;
        }

        static void Swap(ref Student a, ref Student b)
        {
            Student temp = a;
            a = b;
            b = temp;
        }

        static void Print(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(string.Format("{0}: {1:F2}", students[i].Name, students[i].Grade));
            }
        }

        static Student[] ReadStudents()
        {
            int studentsNumber = Convert.ToInt32(Console.ReadLine());
            Student[] result = new Student[studentsNumber];

            for (int i = 0; i < studentsNumber; i++)
            {
                string[] studentData = Console.ReadLine().Split(':');
                result[i] = new Student(studentData[0].Trim(), Convert.ToDouble(studentData[1].Trim()));
            }

            return result;
        }
    }
}
