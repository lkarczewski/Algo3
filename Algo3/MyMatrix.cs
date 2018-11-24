using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo3
{
    public class MyMatrix<T> where T : new()
    {
        public T[,] Matrix { get; }

        public MyMatrix(T[,] matrix)
        {
            Matrix = matrix;
        }

        public MyMatrix(int rows, int columns)
        {
            var random = new Random();
            var matrix = new T[rows, columns];
            double r;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (matrix is double[,])
                    {
                        r = random.Next(-65536, 65535);
                        matrix[i, j] = (dynamic)(r / 65536);
                    }
                }
            }

            Matrix = matrix;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < Rows(); i++)
            {
                for (int j = 0; j < Columns(); j++)
                {
                    Console.Write(this[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        public int Rows()
        {
            return Matrix.GetLength(0); //liczby określają wymiar
        }

        public int Columns()
        {
            return Matrix.GetLength(1);
        }

        public T this[int row, int col]
        {
            get
            {
                return Matrix[row, col];
            }
            set
            {
                Matrix[row, col] = value;
            }
        }

        //norma wektora
        public static double VectorNorm<T1, T2>(T1[] vector, T2[] refVector)
        {
            var sum = 0.0;
            for (var i = 0; i < vector.Length; i++)
            {
                sum += (refVector[i] - (dynamic)vector[i]) * (refVector[i] - (dynamic)vector[i]);
            }

            return Math.Sqrt(sum);
        }

        public void GaussWithoutPivot(T[] vector) //obiekt ma w sobie macierz, ale nie posiada wektora
        {
            LeftBottomTriangle(vector); //redukcja lewego dolnego trójkąta
            RightTopTriangle(vector);   //redukcja prawego górnego trójkąta
            CalculateVector(vector); // obliczanie wektora
        }

        public void GaussPartialPivot(T[] vector)
        {
            LeftBottomTrianglePartialPivot(vector);
            RightTopTriangle(vector);
            CalculateVector(vector);
        }

        public void GaussPartialPivotSparse(T[] vector)
        {
            LeftBottomTrianglePartialPivotSprarse(vector);
            RightTopTriangle(vector);
            CalculateVector(vector);
        }

        public void GaussFullPivot(T[] vector)
        {
            // Wstępne ustalenie który x znajduje się w której kolumnie
            //ustalenie porządku kolumn
            var columnOrder = new int[Columns()];
            for (var i = 0; i < Columns(); i++)
            {
                columnOrder[i] = i;
            }

            LeftBottomTriangleFullPivot(vector, columnOrder);
            RightTopTriangle(vector);
            CalculateVector(vector);

            //przywrócenie porządku kolumn
            // Tutaj bierze indeksy z columnOrder
            // a columnOrder[i] przechowuje indeks aktualnego x bo w vector teraz to x-sy są pomieszane a nie w koljensności x1,x2....
            // a tu posortowany vector przepisuje do głównej zmiennej wektora
            var orderedVector = new T[Columns()];
            for (var i = 0; i < Columns(); i++)
                orderedVector[columnOrder[i]] = vector[i];

            for (var i = 0; i < Columns(); i++)
                vector[i] = orderedVector[i];
        }

        public void LeftBottomTriangle(T[] vector)
        {
            //wybieranie rzędu do zredukowania rzędów poniżej; selected to wiersz, którym będę odejmował;
            for (var selected = 0; selected < Rows() - 1; selected++)
            {
                NoLeadingZero(selected);
                //pętla na każdym rzędie poniżej; current to wiersz, który będzie redukowany
                for (var current = selected + 1; current < Rows(); current++)
                {
                    ReduceRow(vector, selected, current);
                }
            }
        }

        public void SwapRow(int index1, int index2)
        {
            for (var i = 0; i < Columns(); i++)
            {
                var temp = this[index2, i];
                this[index2, i] = this[index1, i];
                this[index1, i] = temp;
            }
        }

        public void SwapColumn(int index1, int index2)
        {
            for (var i = 0; i < Columns(); i++)
            {
                var temp = this[i, index2];
                this[i, index2] = this[i, index1];
                this[i, index1] = temp;
            }
        }

        public int FindMaxInColumn(int selected)
        {
            //wybrany rząd ustawiony jako obecny max
            var currentMaxRowIndex = selected;
            var currentMax = this[selected, selected];

            //sprawdzanie każdego rzędu poniżej wybranego(selected)
            for (var i = selected; i < Rows(); i++)
            {
                if (this[i, selected] > (dynamic)currentMax)
                {
                    currentMax = this[i, selected];
                    currentMaxRowIndex = i;
                }
            }

            return currentMaxRowIndex;
        }

        public int[] FindMax(int selected)
        {
            var currentMaxIndex = new int[] { selected, selected };
            var currentMax = this[selected, selected];

            for (var i = selected; i < Rows(); i++)
            {
                for (var j = selected; j < Columns(); j++)
                {
                    if (this[i, j] > (dynamic)currentMax || this[i, j] < -(dynamic)currentMax)
                    {
                        currentMax = this[i, j];
                        currentMaxIndex = new int[] { i, j };
                    }
                }
            }

            return currentMaxIndex;
        }

        public void ChoosePartialPivot(T[] vector, int selected)
        {
            var maxRow = FindMaxInColumn(selected);

            if (selected != maxRow)
            {
                //zamień rzędy wektora
                var temp = vector[selected];
                vector[selected] = vector[maxRow];
                vector[maxRow] = temp;
            }

            //zamień rzędy macierzy
            SwapRow(selected, maxRow);
        }

        public void LeftBottomTrianglePartialPivot(T[] vector)
        {
            //wybranie rzędu do redukowania rzędów poniżej
            for (var selected = 0; selected < Rows() - 1; selected++)
            {
                NoLeadingZero(selected);
                ChoosePartialPivot(vector, selected);

                //redukowanie rzędów poniżej
                for (var current = selected + 1; current < Rows(); current++)
                {
                    ReduceRow(vector, selected, current);
                }
            }
        }

        public void LeftBottomTrianglePartialPivotSprarse(T[] vector)
        {
            //wybranie rzędu do redukowania rzędów poniżej
            for (var selected = 0; selected < Rows() - 1; selected++)
            {
                NoLeadingZero(selected);
                ChoosePartialPivot(vector, selected);

                //redukowanie rzędów poniżej
                for (var current = selected + 1; current < Rows(); current++)
                {
                    if ((dynamic)this[current, selected] == new T())
                        continue;

                    ReduceRow(vector, selected, current);
                }
            }
        }

        public void LeftBottomTriangleFullPivot(T[] vector, int[] columnOrder)
        {
            //wybranie rzędu do redukowania rzędów poniżej
            for (var selected = 0; selected < Rows() - 1; selected++)
            {
                var max = FindMax(selected);

                //zamiana kolumn
                var tempOrd = columnOrder[selected];
                columnOrder[selected] = columnOrder[max[1]];
                columnOrder[max[1]] = tempOrd;
                SwapColumn(selected, max[1]);

                //zamiana rzędu i wektora
                var temp = vector[selected];
                vector[selected] = vector[max[0]];
                vector[max[0]] = temp;
                SwapRow(selected, max[0]);

                //redukowanie rzędów poniżej
                for (var current = selected + 1; current < Rows(); current++)
                {
                    ReduceRow(vector, selected, current);
                }
            }
        }

        public void RightTopTriangle(T[] vector)
        {
            for (var selected = Rows() - 1; selected >= 1; selected--)
            {
                NoLeadingZero(selected);
                for (var current = selected - 1; current >= 0; current--)
                {
                    ReduceRow(vector, selected, current);
                }
            }
        }

        private void NoLeadingZero(int selected)
        {
            if (this[selected, selected] == (dynamic)new T()) //dynamic, bo dopiero czasie wykonania zostanie określony typ 
                throw new ArgumentException("Znaleziono ZERO w diagonalnej macierzy!");
        }

        private void ReduceRow(T[] vector, int selected, int current)
        {
            //jeśli wybrany rząd jest zredukowany, return
            if (this[current, selected] == (dynamic)new T())
                return;

            //współczynnik do wyzerowania rzędu
            var scalar = this[current, selected] / (dynamic)this[selected, selected];

            //odejmowanie wybranego rzędu (pomnożonego przez scalar) od obecnego rzędu
            for (var col = 0; col < Columns(); col++)
            {
                //odejmowanie każdej kolumny
                this[current, col] -= this[selected, col] * scalar;
            }

            //odejmowanie rzędów wektora (pomnożone przez scalar)
            vector[current] -= vector[selected] * scalar;
        }

        public void CalculateVector(T[] v)
        {
            for (var i = 0; i < Rows(); i++)
            {
                v[i] = v[i] / (dynamic)this[i, i]; //obliczanie współczynnika równania
                this[i, i] = this[i, i] / (dynamic)this[i, i]; // zapisanie współczynnika równania w macierzy
            }
        }

        private double SumNonLeadingElements(T[] vector, int row)
        {
            var result = 0.0;

            for(var col = 0; col < Columns(); col++)
            {
                if (col != row)
                {
                    result += (dynamic)this[row, col] * vector[col];
                }
            }

            return result;
        }

        private double Approximate(T[] bVector, T[] xVector, int row)
        {
            var nonLeadingElementsSum = SumNonLeadingElements(xVector, row);
            var leadingElement = this[row, row];

            var Approximation = ((dynamic)bVector[row] - nonLeadingElementsSum) / leadingElement;
            return Approximation;
        }

        public void Jacobi(T[] bVector, int iter)
        {
            var xVector = new T[Columns()];
            for(var it = 0; it < iter; it++)
            {
                var xVectorPrevious = (T[])xVector.Clone();
                for(var row = 0; row < Rows(); row++)
                {
                    xVector[row] = (dynamic)Approximate(bVector, xVectorPrevious, row);
                }
            }

            for (var i = 0; i <Rows(); i++)
            {
                bVector[i] = xVector[i];
            }
        }

        public void Seidel(T[] bVector, int iter)
        {
            var xVector = new T[Columns()];
            for (var it = 0; it < iter; it++)
            {   
                for (var row = 0; row < Rows(); row++)
                {
                    xVector[row] = (dynamic)Approximate(bVector, xVector, row);
                }
            }

            for (var i = 0; i < Rows(); i++)
            {
                bVector[i] = xVector[i];
            }
        }
    }
}
