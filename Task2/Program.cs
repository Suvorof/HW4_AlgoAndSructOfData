using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            // Решить задачу о нахождении длины максимальной подпоследовательности с помощью матрицы.
            // Константин Суворов. Санкт-Петербург.

            int[] arr1 = { 2, 4, 8, 9, 10};
            int[] arr2 = { 2, 4, 5, 9};

            string str1 = null;
            string str2 = null;
            for (int i = 0; i < arr1.Length; i++)
            {
                str1 += $"{arr1[i]} ";
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                str2 += $"{arr2[i]} ";
            }

            int result = largestSubsequence(arr1, arr2);

            Console.WriteLine($"\nРазмер наибольшей подпоследовательности двух последовательностей: |{str1}| и |{str2}| \nравен {result}.");
            Console.ReadKey();
        }

        public static int largestSubsequence(int[] FS, int[] SS)
        {
            int[,] Matrix = new int[SS.Length + 1, FS.Length + 1];
            Matrix[0, 0] = 0;
            int maxDimensionSubsequence = FS.Length > SS.Length ? FS.Length : SS.Length;
            int[] Subsequence = new int[maxDimensionSubsequence];
            int dimensionSubsequence = 0;

            for (int i = 1; i < FS.Length + 1; i++) // Заполняем 0-ую строку матрицы элементами 1-ой последовательности
                Matrix[0, i] = FS[i - 1];

            for (int j = 1; j < SS.Length + 1; j++) // Заполняем 0-ой столбец матрицы элементами 2-ой последовательности
                Matrix[j, 0] = SS[j - 1];

            for(int j = 1; j < SS.Length + 1; j++) // Заполняем остальные элементы матрицы
            {
                for(int i = 1; i < FS.Length + 1; i++)
                {
                    if (Matrix[j, 0] == Matrix[0, i])
                    {
                        Matrix[j, i]++;
                        dimensionSubsequence += Matrix[j, i]; //Определяем мощность результирующей подпоследовательности (размерность)
                        Subsequence[i - 1] = Matrix[0, i]; // Заполняем массив подпоследовательности общими элементами рассматриваемых последовательностей

                    }
                    else
                        Matrix[j, i] = 0;
                }
            }

            Console.WriteLine("Матрица пересечения двух последовательностей:\n0 - нет совпадений.\n1 - есть совпадения.\n");
            for(int i = 0; i < Matrix.GetLength(0); i++) // Выводим получившуюся матрицу в консоль 
            {
                for(int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write($"{Matrix[i, j]}   ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Вид подпоследовательности, общей для двух последовательностей: ");
            Console.Write("|");
            for (int i = 0; i < Subsequence.Length; i++) // Выводим наибольшую общую подпоследовательность в консоль  
            {
                if(Subsequence[i] != 0)
                    Console.Write($"{Subsequence[i]} ");

            }
            Console.Write("|\n");
            return dimensionSubsequence;
        }
    }
}
