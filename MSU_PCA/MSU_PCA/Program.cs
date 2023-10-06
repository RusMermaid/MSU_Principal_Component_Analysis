using System;
using System.IO;
using MathNet.Numerics.LinearAlgebra;
using Math = System.Math;

namespace MSU_PCA
{
    class MainClass
    {
        public static unsafe void Main(string[] args)
        {
            Matrix<double> X = Read_Txt2Matrix();
            Matrix<double> Sigma = X.Transpose() * X;
            
            Console.WriteLine("Matrix X:");
            Console.WriteLine(X);
            Console.WriteLine("Matrix Sigma:");
            Console.WriteLine(Sigma);
            Console.WriteLine("Matrix Eigen values of Sigma:");
            Console.WriteLine(MatrixUtil.Sob_Z12(Sigma));
            Console.WriteLine("Matrix Eigen vectors of Sigma:");
            Console.WriteLine(MatrixUtil.Sob_V(Sigma));
        }

        
        static Matrix<double> Read_Txt2Matrix()
        {
            string[] lines = File.ReadAllLines(PathMaker("PCA/PCA1/ArtistsClean.txt"));
            int numRows = lines.Length;
            int numCols = lines[0].Split(',').Length;
            var matrix = Matrix<double>.Build.Dense(numRows, numCols);

            for (int i = 0; i < numRows; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < numCols; j++)
                {
                    double value;
                    if (double.TryParse(values[j], out value))
                    {
                        matrix[i, j] = value;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid numeric value at row {i + 1}, column {j + 1}");
                        return null;
                    }
                }
            }
            return matrix;
        }

        static string PathMaker(string innerPath)
        {
            return string.Concat(Environment.CurrentDirectory.AsSpan(0, Environment.CurrentDirectory.IndexOf("bin", StringComparison.Ordinal)), innerPath);
        }
    }
}