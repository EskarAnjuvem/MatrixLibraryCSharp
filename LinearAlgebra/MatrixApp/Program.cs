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
            int choice;
            Console.WriteLine("Welcome to the Matrix App");
            Console.WriteLine("\n We have the following options for Matrices:");
            Console.WriteLine("1 - Provide Input to Create a single Matrix & perform Matrix Algebra");
            Console.WriteLine("2 - Provide Input for Creating Two Matrices and perform Matrix Algebra");
            Console.Write("Enter your choice:");
            choice = int.Parse(Console.ReadLine());
            while((choice != 1) && (choice != 2))
            {
                Console.Write("Invalid Input. Please enter the number for your choice:");
                choice = int.Parse(Console.ReadLine());
            }

            if(choice == 1)
            {
                Matrix matrixA = UserCreateMatrix();
                Console.WriteLine("The following operations are available.");
                Console.WriteLine("1 - Transpose , 2 - Inverse, 3 -Trace, 4 - Rank");
                Console.Write("Enter the result you want:");
                int operationChoice = int.Parse(Console.ReadLine());
                if (operationChoice == 1)
                {
                    Matrix transposeA = MatrixTranspose(matrixA);
                    Console.WriteLine("The transpose of input matrix is: ");
                    PrintMatrix(transposeA);

                    Matrix transposeProduct = MatrixMultiply(matrixA, transposeA);
                    Console.WriteLine("The product of input matrix and its transpose is: ");
                    PrintMatrix(transposeProduct);

                }

            }
            else
            {
                Matrix matrixA = UserCreateMatrix();
                Matrix matrixB = UserCreateMatrix();
            }
            

            Console.ReadLine();
        }

        public static Matrix UserCreateMatrix()
        {
            Console.WriteLine("Enter the order of Matrix you want to create - ");
            Console.Write("Rows:");
            int matrixRows = int.Parse(Console.ReadLine());
            while (matrixRows < 0)
            {
                Console.Write("Matrix Creation will fail. Enter a positive value.");
                matrixRows = int.Parse(Console.ReadLine());
            }
            Console.Write("Columns:");
            int matrixColumns = int.Parse(Console.ReadLine());
            while (matrixColumns < 0)
            {
                Console.Write("Matrix Creation will fail. Enter a positive value.");
                matrixColumns = int.Parse(Console.ReadLine());
            }

            Matrix matrix = new Matrix(matrixRows, matrixColumns);

            for (int i = 0; i < matrixRows; i++)
            {
                Console.WriteLine("Enter the elements of row {0}:", i + 1);
                for (int j = 0; j < matrixColumns; j++)
                {
                    matrix[i, j] = double.Parse(Console.ReadLine()); // Exception not yet handled
                }
            }

            Console.WriteLine("Your Input Matrix is:");
            PrintMatrix(matrix);

            return matrix;

        }
        public static Matrix MatrixTranspose(Matrix matrix)
        {
            Matrix transposeMatrix = new Matrix(matrix.Columns, matrix.Rows);
            for (int i = 0; i < transposeMatrix.Rows; i++)
            {
                for (int j = 0; j < transposeMatrix.Columns; j++)
                {
                    transposeMatrix[i, j] = matrix[j,i];
                }
            }
            return transposeMatrix; 
        }
        public static void PrintMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Console.Write("{0}  ", matrix[i, j]);
                }
                Console.WriteLine("");
            }
        }
        public static Matrix MatrixMultiply(Matrix firstMatrix, Matrix secondMatrix)
        {
            if( firstMatrix.Columns == secondMatrix.Rows)
            {
                Matrix productMatrix = new Matrix(firstMatrix.Rows, secondMatrix.Columns);
                for(int i = 0; i < firstMatrix.Rows; i++)
                {
                    for (int j = 0; j < secondMatrix.Columns; j++)
                    {
                        productMatrix[i, j] = 0;
                        for (int k = 0; k < firstMatrix.Columns; k++)
                        {
                            productMatrix[i,j] += firstMatrix[i, k] * secondMatrix[k,j];
                        }
                    }
                }
                return productMatrix;
            }
            else
            {
                Console.WriteLine("Matrices cannot be multiplied dut to incompatible size.");
                Console.WriteLine("Matrix of order m x n can be multiplied only with a matrix of order n x p.");
                return null;
            }
        }
    }
}
