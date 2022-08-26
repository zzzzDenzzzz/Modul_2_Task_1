using System;
using System.Linq;

/*Задание 1
Объявить одномерный (5 элементов) массив с именем A и двумерный массив (3 строки, 4 столбца) дробных чисел с именем B.
Заполнить одномерный массив А числами, введенными с клавиатуры пользователем, а 
двумерный массив В случайными числами с помощью циклов. Вывести на экран значения массивов: массива 
А в одну строку, массива В — в виде матрицы. Найти в данных массивах общий максимальный элемент,
минимальный элемент, общую сумму всех элементов, общее произведение всех элементов, сумму четных элементов 
массива А, сумму нечетных столбцов массива В.*/

namespace Modul_2_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeA = 5;
            double[] A = new double[sizeA];

            int lines = 3;
            int columns = 4;
            double[,] B = new double[lines, columns];
            Random random = new Random();

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = random.Next(1, 9) * 0.2;
                }
            }

            Console.WriteLine("Массив B: ");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write($"{B[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Заполните массив A");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("введите число: ");
                A[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("Массив A: ");
            foreach (var item in A)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            var bufAr = B.Cast<double>().Select(c => c).ToArray();

            double max = A[0];
            double min = A[0];
            bool flag = false;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < bufAr.Length; j++)
                {
                    if (A[i] == bufAr[j])
                    {
                        max = (max > A[i]) ? max : A[i];
                        min = (min < A[i]) ? min : A[i];
                        flag = true;
                    }
                }
            }

            if (flag)
            {
                Console.WriteLine($"\nМаксимальное значение в двух массивах = {max}");
                Console.WriteLine($"Минимальное значение в двух массивах = {min}");
            }
            else
            {
                Console.WriteLine("Совпадений нет");
            }

            double[] res = A.Union(bufAr).ToArray();
            Console.WriteLine($"Сумма всех элементов двух массивов = {res.Sum()}");

            double _res = 1;
            for (int i = 0; i < res.Length; i++)
            {
                _res *= res[i];
            }
            Console.WriteLine($"Произведение всех элементов двух массивов = {_res}");

            double sum2 = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sum2 += A[i];
                }
            }
            Console.WriteLine($"Сумма четных элементов массива А = {sum2}");

            sum2 = 0;
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (j % 2 != 0)
                    {
                        sum2 += B[i, j];
                    }
                }
            }
            Console.WriteLine($"Сумма нечетных столбцов массива В = {sum2}");
        }
    }
}
