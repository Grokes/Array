using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    internal static class Task
    {
        public static void Task1()
        {
            double[] A = new double[5];
            double[,] B = new double[3, 4];
            Random ran = new Random();

            //Заполнение
            for (int i = 0; i < A.Length; ++i)
                A[i] = double.Parse(Console.ReadLine());

            for (int i = 0; i < B.GetLength(0); ++i)
                for (int j = 0; j < B.GetLength(1); ++j)
                    B[i, j] = ran.Next(10);
            //Вывод
            PrintArr(A);
            Console.WriteLine();
            PrintArr(B);

            // Общая сумма
            double ArrSum = A.Sum();

            foreach (var el in B)
                ArrSum += el;

            // Общее произведение
            double ArrProizved = 1;
            foreach (var el in B)
                ArrProizved *= el;
            foreach (var el in A)
                ArrProizved *= el;

            // Сумма чётных элементов массива A
            double SumEvenA = 0;
            for (int i = 0; i < A.Length; ++i)
            {
                if (i % 2 != 0) // тк индекс, а не порядковый номер
                    SumEvenA += A[i];
            }
            // Сумма нечётных столбцов массива B
            double SumOddColumnB = 0;
            for (int i = 0; i < B.GetLength(0); ++i)
            {
                for (int j = 0; j < B.GetLength(1); ++j)
                {
                    if (j % 2 == 0)
                        SumOddColumnB += B[i, j];
                }
            }

            List<double> common = new List<double>();
            for (int i = 0; i < B.GetLength(0); ++i)
            {
                for (int j = 0; j < B.GetLength(1); ++j)
                {
                    if (A.Contains(B[i, j]) && !common.Contains(B[i, j]))
                    {
                        common.Add(B[i, j]);
                    }
                }
            }

            Console.WriteLine($"Общая сумма {ArrSum}");
            Console.WriteLine($"Общее произведение {ArrProizved}");
            Console.WriteLine($"Сумма чётных элементов A {SumEvenA}");
            Console.WriteLine($"Сумма нечётных столбцов B {SumOddColumnB}");
            try
            {
                Console.WriteLine($"Максимальный общий элемент {common.Max()}");
            }
            catch { }
            try
            {
                Console.WriteLine($"Минимальный общий элемент {common.Min()}");
            }
            catch { }
        }
        public static void Task2()
        {
            int[,] arr = new int[5, 5];
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); ++i)
                for (int j = 0; j < arr.GetLength(1); ++j)
                    arr[i, j] = rand.Next(-100, 100);

            int sum = 0;
            int indexMin = arr.Cast<int>().Min();
            int indexMax = arr.Cast<int>().Max();
            for (int i = 0; i < arr.GetUpperBound(0) + 1; ++i)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; ++j)
                    Console.Write(arr[i, j] + ", ");
                Console.WriteLine();
            }
            
            PrintArr(arr);
            Console.WriteLine(indexMin);
            Console.WriteLine(indexMax);

            
        }
        static void PrintArr(double[] arr)
        {
            foreach (var el in arr)
                Console.Write(el + ", ");
        }
        static void PrintArr(double[,] arr)
        {
            for (int i = 0; i < arr.GetUpperBound(0) + 1; ++i)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; ++j)
                    Console.Write(arr[i, j] + ", ");
                Console.WriteLine();
            }
        }
        static void PrintArr(int[,] arr)
        {
            for (int i = 0; i < arr.GetUpperBound(0) + 1; ++i)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; ++j)
                    Console.Write(arr[i, j] + ", ");
                Console.WriteLine();
            }
        }
    }
}
