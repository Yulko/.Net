using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Matrix
    {
         public static double[,] CreateMatrix(int col, int row, int max, int min)
         {
            Random r = new Random();

            double[,] matrix = new double[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = r.NextDouble() * (max - min) + min;
                }
            }

            return matrix;
        }

        public static void PrintMultypleMatrix(double [,] m1, double [,] m2)
        {
            try
            {
                if (m1.GetLength(1) == m2.GetLength(0))
                {
                    CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                    CancellationToken token = cancelTokenSource.Token;

                    Task.Run(() =>
                    {
                        int m1R = m1.GetLength(0);
                        int m2C = m2.GetLength(1);
                        int m2R = m2.GetLength(0);

                        List<Task> tasks = new List<Task>();

                        double[,] res = new double[m1R, m2C];

                        for (int i = 0; i < m1R; i++)
                        {
                            for (int j = 0; j < m2C; j++)
                            {
                                int row = i;
                                int col = j;
                                tasks.Add(Task.Run(() =>
                                {
                                    if (token.IsCancellationRequested)
                                    {
                                        token.ThrowIfCancellationRequested();
                                    }

                                    for (int k = 0; k < m2R; k++)
                                    {
                                        res[row, col] += m1[row, k] * m2[k, col];
                                    }
                                }, token));
                            }
                        }

                        //cancelTokenSource.Cancel();      

                        if (!token.IsCancellationRequested)
                        {
                            Task.WaitAll(tasks.ToArray());

                            for (int i = 0; i < m1R; i++)
                            {
                                for (int j = 0; j < m2C; j++)
                                {
                                    Console.Write(res[i, j] + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                    }, token);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}