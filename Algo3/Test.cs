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

        public void MonteCarlo(int interations, int numOfAgents,int numOfYes)
        {
            int[] tableOfAgents = GenerateRandomTableOfAgents(numOfAgents, numOfYes);

            Console.WriteLine("Agents:");
            for (int i = 0; i < tableOfAgents.Length; i++)
            {
                Console.Write(tableOfAgents[i] + " ");
            }

            Console.WriteLine();
            List<PairOfAgents> listOfPairs = DrawPairOfAgents(numOfAgents, tableOfAgents);

            Console.WriteLine("Pairs of agents:");
            foreach (PairOfAgents i in listOfPairs)
            {
                Console.WriteLine("First agent: " + i.firstAgent + "\t\tSecond agent: " + i.secondAgent + 
                    "\t\tFirst index: " + i.firstAgentIndex + "\t\tSecond index: " + i.secondAgentIndex);
            }
        }

        public int[] GenerateRandomTableOfAgents(int numberOfAgents, int numberOfYes)
        {
            int numberOfNo = numberOfYes / 2;
            int numberOfUn = numberOfAgents - numberOfNo - numberOfYes;
            int[] table = new int[numberOfAgents];

            for (int i = 0; i < numberOfYes; i++)
            {
                table[i] = 1;
            }

            for (int i = 0; i < numberOfNo; i++)
            {
                table[i + numberOfYes] = -1;
            }

            for (int i = 0; i < numberOfUn; i++)
            {
                table[i + numberOfYes + numberOfNo] = 0;
            }

            Random rnd = new Random();
            table = table.OrderBy(x => rnd.Next()).ToArray();

            return table;
        }

        public struct PairOfAgents
        {
            public int firstAgent;
            public int secondAgent;
            public int firstAgentIndex;
            public int secondAgentIndex;

            public PairOfAgents(int fA, int sA, int fAI, int sAI)
            {
                firstAgent = fA;
                secondAgent = sA;
                firstAgentIndex = fAI;
                secondAgentIndex = sAI;
            }
        }

        public List<PairOfAgents> DrawPairOfAgents(int numberOfAgents, int[] tableOfAgents)
        {
            // int[] tableOfAgents = GenerateRandomTableOfAgents(numberOfAgents,18);
            double probability = (2 / (numberOfAgents * (numberOfAgents - 1)));
            int[,] tableOfPairs = new int[numberOfAgents/2,4];
            List<PairOfAgents> listOfPairs = new List<PairOfAgents>();
            Random rnd = new Random();
            int k = 0;

            for (int i = 0; i < numberOfAgents; i++)
            {
                for (int j = i+1; j < numberOfAgents; j++)
                {
                    PairOfAgents n = new PairOfAgents(tableOfAgents[i], tableOfAgents[j], i,  j);
                    listOfPairs.Add(n);
                    k++;
                }
            }

            return listOfPairs;
        }
    }
}
