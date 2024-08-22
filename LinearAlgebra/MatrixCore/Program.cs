using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraLib.MatrixCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Matrix
    {
        private int matrixRows;
        private int matrixColumns;
        private double[,] data;

             
        public int Rows 
        { 
            get { return matrixRows; }
        }

        public int Columns
        {
            get { return matrixColumns; }
        }

        public double this[int row, int column]
        {
            get 
            {
                if (row < 0 || column < 0 || row >= matrixRows || column >= matrixColumns)
                    throw new IndexOutOfRangeException("Invalix Matrix index");
                return data[row, column];
            }

            set
            {
                if (row < 0 || column < 0 || row >= matrixRows || column >= matrixColumns)
                    throw new IndexOutOfRangeException("Invalix Matrix index");
                data[row, column] = value;
            }
        }

        public Matrix(int rows, int columns)
        {
            if (rows < 0 || columns < 0)
                throw new ArgumentException("Matrix dimensions must be positive.");
            
            this.matrixRows = rows;
            this.matrixColumns = columns;

            data = new double[rows, columns];
        }


    }
}
