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
            Vector<double> A = MatrixUtil.FindA(Sigma);
            
            Console.WriteLine("Matrix X:");
            Console.WriteLine(X);
            Console.WriteLine("Matrix Sigma:");
            Console.WriteLine(Sigma);
            //Console.WriteLine("Matrix Eigen values of Sigma:");
            //Console.WriteLine(MatrixUtil.Sob_Z12(Sigma));
            Console.WriteLine("Matrix Eigen vectors of Sigma:");
            Console.WriteLine(MatrixUtil.Sob_V(Sigma));
            Console.WriteLine("Vector A:");
            Console.WriteLine(A);
        }

        
        // Function to find the eigenvector corresponding to the maximum eigenvalue
        
        
        static Matrix<double> Read_Txt2Matrix()
        {
            string[] lines = File.ReadAllLines(PathMaker("PCA/PCA1/ArtistsClean.txt"));
            var matrix = Matrix<double>.Build.Dense(lines.Length, lines[0].Split(',').Length);

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Split(',').Length; j++)
                {
                    double value;
                    if (double.TryParse(lines[i].Split(',')[j], out value))
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