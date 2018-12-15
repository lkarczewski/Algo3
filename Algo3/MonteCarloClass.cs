using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo3
{
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

    class MonteCarloClass
    {
        private Random rnd = new Random();

        public bool MonteCarlo(int numberOfAgents)
        {
            int numberOfYes = numberOfAgents / 2;
            int numberOfNo = numberOfAgents / 2;
            int[] tableOfAgents = GenerateRandomTableOfAgents(numberOfAgents, numberOfYes, numberOfNo);
            int i = 1;

            do
            {
                PairOfAgents picked = Draw(tableOfAgents);

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

            if (CheckAgentsYes(tableOfAgents))
            {
                //wygrana, wszyscy na tak
                return 1;
            }
            else if (CheckAgentsNo(tableOfAgents))
            {
                //przegrana, wszyscy na nie lub nie wiem
                return -1;
            }
            else
                //graj dalej
                return 0;
        }

        public bool CheckAgentsYes(int[] tableOfAgents)
        {
            for (int i = 0; i < tableOfAgents.Length; i++)
            {
                if (tableOfAgents[i] != 1)
                    return false;
            }

            return true;
        }

        public bool CheckAgentsNo(int[] tableOfAgents)
        {
            for (int i = 0; i < tableOfAgents.Length; i++)
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

            table = table.OrderBy(x => rnd.Next()).ToArray();

            return table;
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
    }
}
