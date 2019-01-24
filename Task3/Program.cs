using System;

namespace Task3
{

    class Program
    {
        // *** Требуется обойти конём шахматную доску размером N * M, пройдя через все поля доски по одному разу.
        // Константин Суворов. Санкт-Петербург.
        // Недорешал...

        public static int M = 30;
        public static int[,] offset = new int[8, 2];

        static void Main()
        {
            int[,] A = new int[M, M];
            int[] steps = new int[8];
            int x = 3, y = 3, count = 1, idx = 0;

            Console.Write("Введите x: ");
            x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите y: ");
            y = Convert.ToInt32(Console.ReadLine());

            offset[0, 0] = 2; offset[0, 1] = 1;
            offset[1, 0] = 2; offset[1, 1] = -1;
            offset[2, 0] = 1; offset[2, 1] = 2;
            offset[3, 0] = 1; offset[3, 1] = -2;
            offset[4, 0] = -1; offset[4, 1] = 2;
            offset[5, 0] = -1; offset[5, 1] = -2;
            offset[6, 0] = -2; offset[6, 1] = 1;
            offset[7, 0] = -2; offset[7, 1] = -1;

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    A[i, j] = 0;
                }
            }
            A[x, y] = count;

            do
            {
                for (int k = 0; k < 8; k++)
                {
                    steps[k] = numberOfSteps(x + offset[k, 0], y + offset[k, 1], A);
                }
                for (int k = 0; k < 8; k++)
                {
                    if (steps[k] > 0)
                    {
                        idx = k;
                        break;
                    }
                    if (k == 7)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (steps[i] == 0)
                            {
                                A[x + offset[i, 0], y + offset[i, 1]] = ++count;
                            }
                        }
                        printArray(A);
                    }
                }
                for (int k = 0; k < 8; k++)
                {
                    if (steps[k] < steps[idx] && steps[k] > 0)
                    {
                        idx = k;
                    }
                }

                x += offset[idx, 0];
                y += offset[idx, 1];
                A[x, y] = ++count;

            } while (true);

        }

        public static int numberOfSteps(int x, int y, int [,] A)
        {
            A = new int[M, M];

            if ((x < 0 || x >= M || y < 0 || y >= M || A[x, y] != 0))
            {
                return -1;
            }
            int count = 0;
            for (int k = 0; k < 8; k++)
            {
                int xn = x + offset[k, 0];
                int yn = y + offset[k, 1];
                if (xn >= 0 && xn < M && yn >= 0 && yn < M && A[xn, yn] == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public static void printArray(int [,] A)
        {
            A = new int[M, M];

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write($"{A[i, j]}    ");
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
