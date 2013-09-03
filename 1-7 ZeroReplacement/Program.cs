using System;
using System.Collections.Generic;

namespace _1_7_ZeroReplacement
{
    class Program
    {
        static void Main(string[] args)
        {
        	int[,] a = new int[,] { {10, 0, 9, 20}, {30, 40, 0, 60}, { 1, 2, 3, 4} };

        	Matrix m = new Matrix(a);
        	m.Print();

            m.Replace();

            Console.WriteLine();
            m.Print();
        }
    }

    class MatrixElement
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }

    class Matrix
    {
    	private int[,] _matrix = null;
    	private int _rows = 0;
    	private int _cols = 0;
        //private ICollection<MatrixElement> _zeroElements = new List<MatrixElement>();
        private LinkedList<MatrixElement> _zeroElements = new LinkedList<MatrixElement>();

    	public Matrix(int[,] matrix)
    	{
    		_matrix = matrix;
    		_rows = matrix.GetLength(0);
    		_cols = matrix.GetLength(1);
    	}

    	public void Replace()
    	{
            IdentifyZeros();

            foreach (MatrixElement p in _zeroElements)
            {
                ReplaceRow(p.Row);
                ReplaceCol(p.Col);
            }
    	}

        private void ReplaceRow(int row)
        {
            for (int i = 0; i < _cols; i++)
            {
                _matrix[row, i] = 0;
            }
        }

        private void ReplaceCol(int col)
        {
            for (int i = 0; i < _rows; i++)
            {
                _matrix[i, col] = 0;
            }
        }

        private void IdentifyZeros()
        {
           for (int i = 0; i < _rows; i++)      
           {
                for (int j = 0; j < _cols; j++)
                {
                    if (_matrix[i, j] == 0)
                    {
                        _zeroElements.AddLast(new MatrixElement { Row = i, Col = j });
                    }
                }
           }
        }

    	public void Print()
    	{
    		for (int i = 0; i < _rows; i++)
    		{
    			for (int j = 0; j < _cols; j++)
    			{
    				Console.Write("{0} ", _matrix[i, j]);
    			}

    			Console.WriteLine();
    		}
    	}
    }
}
