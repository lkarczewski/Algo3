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
            Test t = new Test();
            //t.GaussPartialPivotTest(3,1000);

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

            //Test test = new Test();
            //int win = 0;
            //int loose = 0;
            //int iterations = 1000000;
            //bool result;

            //for (int i = 0; i < iterations; i++)
            //{
            //    result = test.MonteCarlo(5, 2, 2);
            //    if (result)
            //        win++;
            //    else
            //        loose++;
            //}

            //Console.WriteLine("Wygrane:" + win);
            //Console.WriteLine("Przegrane:" + loose);

            MatrixGenerator mg = new MatrixGenerator(15);
            MyMatrix<double> macierz = new MyMatrix<double>(mg.size, mg.size);
            double[] wektor = new double[mg.size];

            macierz = mg.GenerateMatrix();
            wektor = t.GenerateVector(mg.size);

            //Console.WriteLine(macierz.SeidelAccuracy(wektor, 1e-6));

            //macierz.PrintMatrix();
            macierz.GaussPartialPivot(wektor);
            //Console.WriteLine();
            //macierz.PrintMatrix();
            //Console.WriteLine();
            t.PrintVector(wektor);
        }
    }

}
