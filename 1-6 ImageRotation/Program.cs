using System;

namespace _1_6_ImageRotation
{
    class Program
    {
        static void Main(string[] args)
        {
        	Image image = new Image(new int[,] { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} });
        	image.Print();
        	image.Rotate();
        	Console.WriteLine();
        	image.Print();
        }
    }

    class Image
    {
    	private int[,] _image;
    	private int _rows;
        private int _cols;

        public Image(int[,] image)
        {
            _image = image;
            _rows = image.GetLength(0);
            _cols = image.GetLength(1);
        }

    	public void Print()
    	{
    		for (int r = 0; r < _rows; r++)
    		{
    			for (int c = 0; c < _cols; c++)
    			{
                    //Console.WriteLine("({0}, {1}) -> ({2}, {3})", r, c, _rows - c - 1, r);

                    Console.Write("{0} ", _image[r, c]);
    			}

    			Console.Write("\n");
    		}
    	}

    	public void Rotate()
    	{
    		int[,] newImage = new int[_rows, _cols];

    		for (int r = 0; r < _rows; r++)
    		{
    			for (int c = 0; c < _cols; c++)
    			{
    				newImage[_rows - c - 1, r] = _image[r, c];
    			}
    		}

    		_image = newImage;
    	}
    }
}
