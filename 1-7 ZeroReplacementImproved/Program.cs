using System;

namespace _1_7_ZeroReplacementImproved
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

    class Matrix
    {
    	private int[,] _matrix = null;
    	private int _rows = 0;
    	private int _cols = 0;
    	private bool[] _zeroRows;
    	private bool[] _zeroCols;

    	public Matrix(int[,] matrix)
    	{
    		_matrix = matrix;
    		_rows = matrix.GetLength(0);
    		_cols = matrix.GetLength(1);
    		_zeroRows = new bool[_rows];
    		_zeroCols = new bool[_cols];
    	}

    	public void Replace()
    	{
            IdentifyZeros();

           for (int i = 0; i < _rows; i++)      
           {
                for (int j = 0; j < _cols; j++)
                {
                	if (_zeroRows[i] || _zeroCols[j])
                	{
                		_matrix[i, j] = 0;
                	}
                }
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
                    	_zeroRows[i] = true;
                    	_zeroCols[j] = true;
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
