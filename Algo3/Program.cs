using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo3
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[,] test = new double[3, 3] { { 8, -2, 3 }, { 2, 3, -1 }, { 5, -2, 7 } };
            //double[] vector = new double[] { 28.6, 12.12, 36.95 };
            //MyMatrix<double> macierz1 = new MyMatrix<double>(test);
            //double[] vector1 = (dynamic)vector.Clone();


            //macierz1.Jacobi(vector1, 20);

            //for (int i = 0; i < vector1.Length; i++)
            //{
            //    Console.WriteLine(vector1[i]);
            //}

            //double[] op = new double[] { 28.6, 12.12, 36.95, 43.53, 5353.53, 211.11, 99.22 };

            //Random rnd = new Random();
            //double[] MyRandomArray = op.OrderBy(x => rnd.Next()).ToArray();

            //for (int i = 0; i < MyRandomArray.Length; i++)
            //{
            //    Console.Write(MyRandomArray[i]);
            //    Console.Write(" ");
            //}
            //Console.WriteLine();

            Test test = new Test();

            bool result = test.MonteCarlo(100000, 500, 300);

            if (result)
                Console.WriteLine("Znaleziono!");
            else
                Console.WriteLine("NIE DEBILE TE AGENTY!");

        }
    }

}
