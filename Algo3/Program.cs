using System;
using System.Collections.Generic;
using System.IO;
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

            //TESTY WYDAJNOŚCI

            //StreamWriter writer = new StreamWriter("CzasGaussPartialPivot.csv", append: true);
            //writer.WriteLine("rozmiar;czas");
            //writer.Close();
            //for (int i = 3; i <= 30; i++)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.GaussPartialPivotTimeTest(i, 10);
            //}

            //StreamWriter writer = new StreamWriter("CzasGaussPartialPivotSparse.csv", append: true);
            //writer.WriteLine("rozmiar;czas");
            //writer.Close();
            //for (int i = 3; i <= 30; i++)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.GaussPartialPivotSparseTimeTest(i, 10);
            //}

            //StreamWriter writer = new StreamWriter("CzasJacobi1e-06.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.JacobiTimeTest(i, 5, 1e-6);
            //}

            //StreamWriter writer = new StreamWriter("CzasJacobi1e-10.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.JacobiTimeTest(i, 5, 1e-10);
            //}

            //StreamWriter writer = new StreamWriter("CzasJacobi1e-14.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.JacobiTimeTest(i, 5, 1e-14);
            //}

            //StreamWriter writer = new StreamWriter("CzasSeidel1e-06.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.SeidelTimeTest(i, 5, 1e-6);
            //}

            //StreamWriter writer = new StreamWriter("CzasSeidel1e-10.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.SeidelTimeTest(i, 5, 1e-10);
            //}

            //StreamWriter writer1 = new StreamWriter("CzasSeidel1e-14.csv", append: true);
            //writer1.WriteLine("rozmiar", "norma");
            //writer1.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.SeidelTimeTest(i, 5, 1e-14);
            //}

            //TESTY DOKŁADNOŚCI

            //StreamWriter writer = new StreamWriter("NormaGaussPartialPivot.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.GaussPartialPivotAccuracyTest(i, 5);
            //}

            //StreamWriter writer = new StreamWriter("NormaGaussPartialPivotSparse.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.GaussPartialPivotSparseAccuracyTest(i, 5);
            //}

            //StreamWriter writer = new StreamWriter("NormaJacobi1e-06.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.JacobiAccuracyTest(i, 1e-6, 5);
            //}

            //StreamWriter writer = new StreamWriter("NormaJacobi1e-10.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.JacobiAccuracyTest(i, 1e-10, 5);
            //}

            //StreamWriter writer = new StreamWriter("NormaJacobi1e-14.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.JacobiAccuracyTest(i, 1e-14, 5);
            //}

            //StreamWriter writer = new StreamWriter("NormaSeidel1e-06.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.SeidelAccuracyTest(i, 1e-6, 5);
            //}

            //StreamWriter writer = new StreamWriter("NormaSeidel1e-10.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.SeidelAccuracyTest(i, 1e-10, 5);
            //}

            //StreamWriter writer = new StreamWriter("NormaSeidel1e-14.csv", append: true);
            //writer.WriteLine("rozmiar", "norma");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.SeidelAccuracyTest(i, 1e-14, 5);
            //}

            //TESTY MONTE CARLO

            //StreamWriter writer7 = new StreamWriter("MonteCarloGaussPartialPivot.csv", append: true);
            //writer7.WriteLine("rozmiar", "błąd");
            //writer7.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.GaussPartialPivotMonteCarloTest(i);
            //}

            //StreamWriter writer = new StreamWriter("MonteCarloGaussPartialPivotSparse.csv", append: true);
            //writer.WriteLine("rozmiar", "błąd");
            //writer.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.GaussPartialPivotSparseMonteCarloTest(i);
            //}

            //StreamWriter writer1 = new StreamWriter("MonteCarloJacobi1e-06.csv", append: true);
            //writer1.WriteLine("rozmiar", "błąd");
            //writer1.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.JacobiMonteCarloTest(i,1e-6);
            //}

            //StreamWriter writer2 = new StreamWriter("MonteCarloJacobi1e-10.csv", append: true);
            //writer2.WriteLine("rozmiar", "błąd");
            //writer2.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.JacobiMonteCarloTest(i, 1e-10);
            //}

            //StreamWriter writer3 = new StreamWriter("MonteCarloJacobi1e-14.csv", append: true);
            //writer3.WriteLine("rozmiar", "błąd");
            //writer3.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.JacobiMonteCarloTest(i, 1e-14);
            //}

            //StreamWriter writer4 = new StreamWriter("MonteCarloSeidel1e-06.csv", append: true);
            //writer4.WriteLine("rozmiar", "błąd");
            //writer4.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.SeidelMonteCarloTest(i, 1e-6);
            //}

            //StreamWriter writer5 = new StreamWriter("MonteCarloSeidel1e-10.csv", append: true);
            //writer5.WriteLine("rozmiar", "błąd");
            //writer5.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.SeidelMonteCarloTest(i, 1e-10);
            //}

            //StreamWriter writer6 = new StreamWriter("MonteCarloSeidel1e-14.csv", append: true);
            //writer6.WriteLine("rozmiar", "błąd");
            //writer6.Close();
            //for (int i = 4; i <= 30; i += 1)
            //{
            //    Console.WriteLine("Ilość agentów: " + i);
            //    t.SeidelMonteCarloTest(i, 1e-14);
            //}
        }
    }

}
