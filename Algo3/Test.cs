using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo3
{
    class Test
    { 
        public void PrintVector(double[] vector)
        {
            for (var i = 0; i < vector.Length; i++)
            {
                Console.WriteLine(vector[i]);
            }
        }

        public double[] GenerateVector(int size)
        {
            double[] vector = new double[size];

            for (int i = 0; i < size-1; i++)
            {
                vector[i] = 0.0;
            }

            vector[size-1] = 1.0;

            return vector;
        }

        public double GetProbabilityFromVector(double[] vector, double monteCarloProbability)
        {
            bool enoughAccuracy = false;
            double accuracy = 1e-3;

            for (int i = 0; i < vector.Length; i++)
            {
                enoughAccuracy = (Math.Abs(vector[i] - monteCarloProbability)) <= accuracy;
                if (enoughAccuracy && (vector[i] != 0))
                {
                    return vector[i];
                }
            }

            return 0;
        }

        public double AbsoluteError(double monteCarloProbability, double vectorProbability)
        {
            return Math.Abs(monteCarloProbability - vectorProbability);
        }

        public void GaussPartialPivotMonteCarloTest(int numberOfAgents)
        {
            MonteCarloClass mc = new MonteCarloClass();
            double win = 0.0;
            double loose = 0.0;
            int iterations = 1000000;
            double monteCarloProbability = 0.0;
            double vectorProbability = 0.0;
            double absoluteError = 0.0;
            bool result;

            for (int i = 0; i < iterations; i++)
            {
                result = mc.MonteCarlo(numberOfAgents);
                if (result)
                    win++;
                else
                    loose++;
            }

            monteCarloProbability = win / iterations;

            MatrixGenerator mg = new MatrixGenerator(numberOfAgents);
            MyMatrix<double> macierz = new MyMatrix<double>(mg.size, mg.size);
            double[] wektor = new double[mg.size];

            macierz = mg.GenerateMatrix();
            wektor = GenerateVector(mg.size);

            macierz.GaussPartialPivot(wektor);
            PrintVector(wektor);
            vectorProbability = GetProbabilityFromVector(wektor, monteCarloProbability);
            absoluteError = AbsoluteError(monteCarloProbability, vectorProbability);
            Console.WriteLine("Błąd bezwzględny: " + absoluteError);

            StreamWriter writer = new StreamWriter("MonteCarloGaussPartialPivot.csv", append: true);
            if (writer != null)
            {
                writer.WriteLine(String.Format(numberOfAgents + ";" + absoluteError + ";"));
            }
            writer.Close();

            Console.WriteLine("Błąd bezwzględny GaussPartialPivot: " + absoluteError);
        }

        public void GaussPartialPivotSparseMonteCarloTest(int numberOfAgents)
        {
            MonteCarloClass mc = new MonteCarloClass();
            double win = 0.0;
            double loose = 0.0;
            int iterations = 1000000;
            double monteCarloProbability = 0.0;
            double vectorProbability = 0.0;
            double absoluteError = 0.0;
            bool result;

            for (int i = 0; i < iterations; i++)
            {
                result = mc.MonteCarlo(numberOfAgents);
                if (result)
                    win++;
                else
                    loose++;
            }

            monteCarloProbability = win / iterations;

            MatrixGenerator mg = new MatrixGenerator(numberOfAgents);
            MyMatrix<double> macierz = new MyMatrix<double>(mg.size, mg.size);
            double[] wektor = new double[mg.size];

            macierz = mg.GenerateMatrix();
            wektor = GenerateVector(mg.size);

            macierz.GaussPartialPivotSparse(wektor);
            PrintVector(wektor);
            vectorProbability = GetProbabilityFromVector(wektor,monteCarloProbability);
            absoluteError = AbsoluteError(monteCarloProbability, vectorProbability);
            Console.WriteLine("Błąd bezwzględny: " + absoluteError);

            StreamWriter writer = new StreamWriter("MonteCarloGaussPartialPivotSparse.csv", append: true);
            if (writer != null)
            {
                writer.WriteLine(String.Format(numberOfAgents + ";" + absoluteError + ";"));
            }
            writer.Close();

            Console.WriteLine("Błąd bezwzględny GaussPartialPivotSparse: " + absoluteError);
        }

        public void JacobiMonteCarloTest(int numberOfAgents, int accuracy)
        {
            MonteCarloClass mc = new MonteCarloClass();
            double win = 0.0;
            double loose = 0.0;
            int iterations = 1000000;
            double monteCarloProbability = 0.0;
            double vectorProbability = 0.0;
            double absoluteError = 0.0;
            bool result;

            for (int i = 0; i < iterations; i++)
            {
                result = mc.MonteCarlo(numberOfAgents);
                if (result)
                    win++;
                else
                    loose++;
            }

            monteCarloProbability = win / iterations;

            MatrixGenerator mg = new MatrixGenerator(numberOfAgents);
            MyMatrix<double> macierz = new MyMatrix<double>(mg.size, mg.size);
            double[] wektor = new double[mg.size];

            macierz = mg.GenerateMatrix();
            wektor = GenerateVector(mg.size);

            macierz.JacobiAccuracy(wektor,accuracy);
            PrintVector(wektor);
            vectorProbability = GetProbabilityFromVector(wektor, monteCarloProbability);
            absoluteError = AbsoluteError(monteCarloProbability, vectorProbability);
            Console.WriteLine("Błąd bezwzględny: " + absoluteError);

            string name = "MonteCarloJacobi" + accuracy + ".csv";
            StreamWriter writer = new StreamWriter(name, append: true);
            if (writer != null)
            {
                writer.WriteLine(String.Format(numberOfAgents + ";" + absoluteError + ";"));
            }
            writer.Close();

            Console.WriteLine("Błąd bezwzględny Jacobi" + accuracy + ": " + absoluteError);
        }

        public void SeidelMonteCarloTest(int numberOfAgents, int accuracy)
        {
            MonteCarloClass mc = new MonteCarloClass();
            double win = 0.0;
            double loose = 0.0;
            int iterations = 1000000;
            double monteCarloProbability = 0.0;
            double vectorProbability = 0.0;
            double absoluteError = 0.0;
            bool result;

            for (int i = 0; i < iterations; i++)
            {
                result = mc.MonteCarlo(numberOfAgents);
                if (result)
                    win++;
                else
                    loose++;
            }

            monteCarloProbability = win / iterations;

            MatrixGenerator mg = new MatrixGenerator(numberOfAgents);
            MyMatrix<double> macierz = new MyMatrix<double>(mg.size, mg.size);
            double[] wektor = new double[mg.size];

            macierz = mg.GenerateMatrix();
            wektor = GenerateVector(mg.size);

            macierz.SeidelAccuracy(wektor, accuracy);
            PrintVector(wektor);
            vectorProbability = GetProbabilityFromVector(wektor, monteCarloProbability);
            absoluteError = AbsoluteError(monteCarloProbability, vectorProbability);
            Console.WriteLine("Błąd bezwzględny: " + absoluteError);

            string name = "MonteCarloSeidel" + accuracy + ".csv";
            StreamWriter writer = new StreamWriter(name, append: true);
            if (writer != null)
            {
                writer.WriteLine(String.Format(numberOfAgents + ";" + absoluteError + ";"));
            }
            writer.Close();

            Console.WriteLine("Błąd bezwzględny Seidel" + accuracy + ": " + absoluteError);
        }

        public void GaussPartialPivotTimeTest(int numberOfAgents, int count)
        {
            MatrixGenerator mg = new MatrixGenerator(numberOfAgents);

            MyMatrix<double> macierz = new MyMatrix<double>(mg.size, mg.size);
            MyMatrix<double> macierzKopia = new MyMatrix<double>(mg.size, mg.size);
            double[] wektor = new double[mg.size];
            double[] wektorKopia = new double[mg.size];

            //przygotowanie macierzy i wektorów
            macierz = mg.GenerateMatrix();
            macierzKopia = mg.GenerateMatrix();
            wektor = wektorKopia = GenerateVector(mg.size);

            //liczenie czasu
            double[] czasy = new double[count];
            double suma = 0.0;
            double srednia = 0.0;

            for (int i = 0; i < count; i++)
            {
                var watchDouble = Stopwatch.StartNew();
                macierz.GaussPartialPivot(wektor);
                watchDouble.Stop();
                var elapsedMsDouble = watchDouble.ElapsedMilliseconds;
                czasy[i] = elapsedMsDouble;

                for (var j = 0; j < macierz.Rows(); j++)
                {
                    for (var k = 0; k < macierz.Columns(); k++)
                    {
                        macierz[j, k] = macierzKopia[j, k];
                        wektor[j] = wektorKopia[j];
                    }
                }
                suma += czasy[i];
            }

            srednia = suma / count;

            StreamWriter writer = new StreamWriter("CzasGaussPartialPivotSparse.csv", append: true);
            if (writer != null)
            {
                writer.WriteLine(String.Format(numberOfAgents + ";" + srednia + ";"));
            }
            writer.Close();

            Console.WriteLine("Średni czas GaussPartialPivotSparse: " + srednia + "ms");
        }

        public void GaussPartialPivotSparseTimeTest(int numberOfAgents, int count)
        {
            MatrixGenerator mg = new MatrixGenerator(numberOfAgents);

            MyMatrix<double> macierz = new MyMatrix<double>(mg.size, mg.size);
            MyMatrix<double> macierzKopia = new MyMatrix<double>(mg.size, mg.size);
            double[] wektor = new double[mg.size];
            double[] wektorKopia = new double[mg.size];

            //przygotowanie macierzy i wektorów
            macierz = mg.GenerateMatrix();
            macierzKopia = mg.GenerateMatrix();
            wektor = wektorKopia = GenerateVector(mg.size);

            //liczenie czasu
            double[] czasy = new double[count];
            double suma = 0.0;
            double srednia = 0.0;

            for (int i = 0; i < count; i++)
            {
                var watchDouble = Stopwatch.StartNew();
                macierz.GaussPartialPivotSparse(wektor);
                watchDouble.Stop();
                var elapsedMsDouble = watchDouble.ElapsedMilliseconds;
                czasy[i] = elapsedMsDouble;

                for (var j = 0; j < macierz.Rows(); j++)
                {
                    for (var k = 0; k < macierz.Columns(); k++)
                    {
                        macierz[j, k] = macierzKopia[j, k];
                        wektor[j] = wektorKopia[j];
                    }
                }
                suma += czasy[i];
            }

            srednia = suma / count;

            StreamWriter writer = new StreamWriter("CzasGaussPartialPivotSparse.csv", append: true);
            if (writer != null)
            {
                writer.WriteLine(String.Format(numberOfAgents + ";" + srednia + ";"));
            }
            writer.Close();

            Console.WriteLine("Średni czas GaussPartialPivotSparse: " + srednia + "ms");
        }

        public void JacobiTimeTest(int numberOfAgents, int count, double accuracy)
        {
            MatrixGenerator mg = new MatrixGenerator(numberOfAgents);

            MyMatrix<double> macierz = new MyMatrix<double>(mg.size, mg.size);
            double[] wektor = new double[mg.size];


            //przygotowanie macierzy i wektorów
            macierz = mg.GenerateMatrix();
            wektor = GenerateVector(mg.size);

            //liczenie czasu
            double[] czasy = new double[count];
            double suma = 0.0;
            double srednia = 0.0;

            for (int i = 0; i < count; i++)
            {
                var watchDouble = Stopwatch.StartNew();
                macierz.JacobiAccuracy(wektor,accuracy);
                watchDouble.Stop();
                var elapsedMsDouble = watchDouble.ElapsedMilliseconds;
                czasy[i] = elapsedMsDouble;

                suma += czasy[i];
                wektor = GenerateVector(mg.size);
            }

            srednia = suma / count;

            string name = "CzasJacobi" + accuracy + ".csv";

            StreamWriter writer = new StreamWriter(name, append: true);
            if (writer != null)
            {
                writer.WriteLine(String.Format(numberOfAgents + ";" + srednia + ";"));
            }
            writer.Close();

            Console.WriteLine("Średni czas Jacobi " + accuracy + ": " + srednia + "ms");
        }

        public void SeidelTimeTest(int numberOfAgents, int count, double accuracy)
        {
            MatrixGenerator mg = new MatrixGenerator(numberOfAgents);

            MyMatrix<double> macierz = new MyMatrix<double>(mg.size, mg.size);
            double[] wektor = new double[mg.size];


            //przygotowanie macierzy i wektorów
            macierz = mg.GenerateMatrix();
            wektor = GenerateVector(mg.size);

            //liczenie czasu
            double[] czasy = new double[count];
            double suma = 0.0;
            double srednia = 0.0;

            for (int i = 0; i < count; i++)
            {
                var watchDouble = Stopwatch.StartNew();
                macierz.SeidelAccuracy(wektor, accuracy);
                watchDouble.Stop();
                var elapsedMsDouble = watchDouble.ElapsedMilliseconds;
                czasy[i] = elapsedMsDouble;

                suma += czasy[i];
                wektor = GenerateVector(mg.size);
            }

            srednia = suma / count;

            string name = "CzasSeidel" + accuracy + ".csv";

            StreamWriter writer = new StreamWriter(name, append: true);
            if (writer != null)
            {
                writer.WriteLine(String.Format(numberOfAgents + ";" + srednia + ";"));
            }
            writer.Close();

            Console.WriteLine("Średni czas Seidel " + accuracy + ": " + srednia + "ms");
        }
    }
}
