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
            double[,] test = new double[3, 3] { { 1, 1, -1 }, { 1, -1, 2 }, { 2, 1, 1 } };
            double[] vector = new double[] { 7.0, 3.0, 9.0 };
            MyMatrix<double> macierz1 = new MyMatrix<double>(test);
            double[] vector1 = (dynamic)vector.Clone();


            macierz1.Seidel(vector1, 10);

            for (int i = 0; i < vector1.Length; i++)
            {
                Console.WriteLine(vector1[i]);
            }
        }
    }
}
