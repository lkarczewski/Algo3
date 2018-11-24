using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo3
{
    class Test
    {
        public double[] GenerateRandomVector(int size)
        {
            Random _random = new Random();
            var vector = new double[size];
            double r;

            for (var i = 0; i < size; i++)
            {
                r = _random.Next(-65536, 65535);
                vector[i] = (dynamic)(r / 65536);
            }

            return vector;
        }

        public void PrintVector(double[] vector)
        {
            for (var i = 0; i<vector.Length; i++)
            {
                Console.WriteLine(vector[i]);
            }
        }

        public void JacobiTest(int size)
        {
            MyMatrix<double> matrix = new MyMatrix<double>(size, size);
            double[] vector = GenerateRandomVector(size);

            matrix.Jacobi(vector, 5);

            matrix.PrintMatrix();
            PrintVector(vector);
        }

        public void SeidelTest(int size)
        {
            MyMatrix<double> matrix = new MyMatrix<double>(size, size);
            double[] vector = new double[size];
        }
    }
}
