using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            int Min = arr.Cast<int>().Min();
            int Max = arr.Cast<int>().Max();

            int[] indMin = Find(arr, Min);
            int[] indMax = Find(arr, Max);

            for (int i = Math.Min(indMin[0], indMax[0]); i < Math.Max(indMin[0], indMax[0]); i++)
            {
                for (int j = Math.Min(indMin[1], indMax[1]); j < Math.Max(indMin[1], indMax[1]); j++)
                {
                    sum += arr[i, j];
                }
            }
            
            PrintArr(arr);
            Console.WriteLine(Min);
            Console.WriteLine(Max);
            Console.WriteLine(sum);
        }
        public static void Task3()
        {
            string temp = Console.ReadLine();
            StringBuilder str = new StringBuilder(temp);

            for (int i = 0; i < str.Length; ++i)
                str[i] = (char)(str[i] + 3);
            Console.WriteLine(str);
            for (int i = 0; i < str.Length; ++i)
                str[i] = (char)(str[i] - 3);
            Console.WriteLine(str);
        }
        public static void Task4()
        {
            int[,] test1 = { { 1, 2 }, { 2, 1 } };
            int[,] test2 = { { 1, 2 }, { 2, 1 } };
            PrintArr(test1);
            Console.WriteLine();
            PrintArr(test2);
            Console.WriteLine();
            PrintArr(MatrixMulti(test1, test2));
            
        }
        public static void Task6()
        {
            string str = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            var temp = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < temp.Length; ++i)
            {
                result.Append(temp[i][0].ToString().ToUpper() + temp[i].Substring(1) + ' ');
            }
            Console.WriteLine(result);
        }

        static int[] Find(int[,] arr,int el)
        {
            int[] result = { -999, -999};
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    if (arr[i, j] == el)
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }
            return result;
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
        static int[,] MatrixMulti(int[,] matrix, int num)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] *= num;
                }
            }
            return matrix;
        }
        static int[,] MatrixAddition(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0) && matrix1.GetLength(1) != matrix2.GetLength(1))
                throw new Exception("Impossible");

            int[,] result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (int i = 0; i < result.GetLength(0); ++i)
            {
                for (int j = 0; j < result.GetLength(1); ++j)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }
        static int[,] MatrixMulti(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
                throw new Exception("Impossible");

            int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int i = 0; i < result.GetLength(0); ++i)
            {
                for (int j = 0; j < result.GetLength(1); ++j)
                {
                    result[i, j] = GetC_ij(matrix1, matrix2, i, j);
                }
            }
            return result;
        }
        static int GetC_ij(int[,] matrix1, int[,] matrix2, int line, int column)
        {
            int result = 0;
            for (int i = 0; i < matrix1.GetLength(1); ++i)
            {
                result += matrix1[line, i] * matrix2[i, column];
            }
            return result;
        }
    }

}
