using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo3
{
    class Test
    {
        private Random rnd = new Random();

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
            for (var i = 0; i < vector.Length; i++)
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

        public bool MonteCarlo(int numOfAgents, int numOfYes, int numOfNo)
        {
            int[] tableOfAgents = GenerateRandomTableOfAgents(numOfAgents, numOfYes, numOfNo);
            //var r = new Random();

            //List<PairOfAgents> listOfPairs = DrawPairOfAgents(numOfAgents, tableOfAgents);

            //Console.WriteLine("Agents ");
            //for (int k = 0; k < tableOfAgents.Length; k++)
            //{
            //    Console.Write(tableOfAgents[k] + " ");
            //}

            int i = 1;
            do
            {
                //PairOfAgents picked = listOfPairs.ElementAt(r.Next(0, listOfPairs.Count));
                PairOfAgents picked = Draw(tableOfAgents);
                //Console.Write(picked.firstAgent + " ");
                //Console.Write(picked.secondAgent + "; ");

                //for (int k = 0; k < tableOfAgents.Length; k++)
                //{
                //    Console.Write(tableOfAgents[k] + " ");
                //}

                //Console.WriteLine();

                if ((picked.firstAgent == 1 && picked.secondAgent == 0) || (picked.firstAgent == 0 && picked.secondAgent == 1))
                {
                    if (picked.firstAgent == 0)
                        tableOfAgents[picked.firstAgentIndex] = 1;
                    else
                        tableOfAgents[picked.secondAgentIndex] = 1;
                }
                else if ((picked.firstAgent == 1 && picked.secondAgent == -1) || (picked.firstAgent == -1 && picked.secondAgent == 1))
                {
                    tableOfAgents[picked.firstAgentIndex] = 0;
                    tableOfAgents[picked.secondAgentIndex] = 0;
                }
                else if ((picked.firstAgent == -1 && picked.secondAgent == 0) || (picked.firstAgent == 0 && picked.secondAgent == -1))
                {
                    if (picked.firstAgent == 0)
                        tableOfAgents[picked.firstAgentIndex] = -1;
                    else
                        tableOfAgents[picked.secondAgentIndex] = -1;
                }

                int score = checkAgentsWinLose(tableOfAgents);
                if (score == 1)
                {
                    return true;
                }
                else if (score == -1)
                    return false;

                i++;
            }
            while (true);
        }

        public int checkAgentsWinLose(int[] tableOfAgents)
        {

            if (checkAgentsYes(tableOfAgents))
            {
                //wygrana, wszyscy na tak
                return 1;
            }
            else if (checkAgentsNo(tableOfAgents))
            {
                //przegrana, wszyscy na nie lub nie wiem
                return -1;
            }
            else
                //graj dalej
                return 0;
        }

        public bool checkAgentsYes(int[] tableOfAgents)
        {
            for (int i = 0; i < tableOfAgents.Length; i++)
            {
                if (tableOfAgents[i] != 1)
                    return false;
            }

            return true;
        }

        public bool checkAgentsNo(int[] tableOfAgents)
        {
            for(int i = 0; i < tableOfAgents.Length; i++)
            {
                if (tableOfAgents[i] != -1)
                {
                    break;
                }

                if (i == tableOfAgents.Length - 1)
                {
                    return true;
                }
            }
            
            for (int i = 0; i < tableOfAgents.Length; i++)
            {
                if (tableOfAgents[i] != 0)
                    return false;
            }

            return true;
        }

        public int[] GenerateRandomTableOfAgents(int numberOfAgents, int numberOfYes, int numberOfNo)
        {
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

        public class PairOfAgents
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

        public PairOfAgents Draw(int[] tableOfAgents)
        {
            int first = rnd.Next(0, tableOfAgents.Length); ;
            int second;

            do
            {
                second = rnd.Next(0, tableOfAgents.Length);
            }
            while (second == first);

            PairOfAgents p = new PairOfAgents(tableOfAgents[first], tableOfAgents[second], first, second);
            return p;
        }

        //public List<PairOfAgents> DrawPairOfAgents(int numberOfAgents, int[] tableOfAgents)
        //{
        //    //wylosuj z rand parę agentów (przedział 0...n/2)
        //    // int[] tableOfAgents = GenerateRandomTableOfAgents(numberOfAgents,18);
        //    //double probability = (2 / (numberOfAgents * (numberOfAgents - 1)));
        //    int[,] tableOfPairs = new int[numberOfAgents/2,4];
        //    List<PairOfAgents> listOfPairs = new List<PairOfAgents>();
        //    int k = 0;

        //    for (int i = 0; i < numberOfAgents; i++)
        //    {
        //        for (int j = i + 1; j < numberOfAgents; j++)
        //        {
        //            PairOfAgents n = new PairOfAgents(tableOfAgents[i], tableOfAgents[j], i, j);
        //            listOfPairs.Add(n);
        //            k++;
        //        }
        //    }

        //    return listOfPairs;
        //}
    }
}
