using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebraLib.MatrixCore;

namespace LinearAlgebraLib.MatrixApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the order of Matrix you want to create - ");
            Console.Write("Rows:");
            int matrixRows = int.Parse(Console.ReadLine());
            Console.Write("Columns:");
            int matrixColumns = int.Parse(Console.ReadLine());

            decimal[,] inputMatrix = new decimal[matrixRows, matrixColumns];
            for (int i = 0; i < matrixRows; i++)
            {
                Console.WriteLine("Enter the elements of row {0}:", i + 1);
                for (int j = 0; j < matrixColumns; j++)
                {
                    inputMatrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Your Input Matrix is:");
            for (int i = 0; i < matrixRows; i++)
            {
                for (int j = 0; j < matrixColumns; j++)
                {
                    Console.Write("{0}  ", inputMatrix[i, j]);
                }
                Console.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}
