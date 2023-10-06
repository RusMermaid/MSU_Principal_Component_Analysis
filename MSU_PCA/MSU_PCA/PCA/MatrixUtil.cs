using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using Math = System.Math;

namespace MSU_PCA;

public class MatrixUtil
{
    
    
    public static MathNet.Numerics.LinearAlgebra.Vector<Complex> Sob_Z1(Matrix<double> mtx)
    {
        return  mtx.Evd().EigenValues;
    }
    
    public static Matrix<double> Sob_Z12(Matrix<double> mtx)
    {
        return  mtx.Evd().D;
    }

    public static Matrix<double> Sob_V(Matrix<double> mtx)
    {
        return  mtx.Evd().EigenVectors;
    }
}