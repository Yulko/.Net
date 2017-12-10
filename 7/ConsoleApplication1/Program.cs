using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] m1 = Matrix.CreateMatrix(1000, 100, 5, 0);
            double[,] m2 = Matrix.CreateMatrix(100, 1000, 5, 0);

            Matrix.PrintMultypleMatrix(m1, m2);

            Console.ReadKey();
        }
    }
}     