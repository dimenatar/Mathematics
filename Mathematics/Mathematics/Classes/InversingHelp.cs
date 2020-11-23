using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mathematics
{
    class InversingHelp
    {
        public static float MatrixDeterminant(float[,] matrix, int n, int m)
        {
            int[] perm;
            int toggle;
            float[,] lum = MatrixDecompose(matrix, out perm, out toggle,  n,  m);
            if (lum == null)
               return 0;
            float result = toggle;
            for (int i = 0; i < lum.GetLength(0); ++i)
                result *= lum[i, i];
            return result;
        }
        public static double[][] MatrixCreate(int rows, int cols)
        {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }

        public static double[][] MatrixIdentity(int n)
        {
            // return an n x n Identity matrix
            double[][] result = MatrixCreate(n, n);
            for (int i = 0; i < n; ++i)
                result[i][i] = 1.0;

            return result;
        }

        public static double[][] MatrixProduct(double[][] matrixA, double[][] matrixB)
        {
            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; int bCols = matrixB[0].Length;
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices in MatrixProduct");

            double[][] result = MatrixCreate(aRows, bCols);

            for (int i = 0; i < aRows; ++i) // each row of A
                for (int j = 0; j < bCols; ++j) // each col of B
                    for (int k = 0; k < aCols; ++k) // could use k less-than bRows
                        result[i][j] += matrixA[i][k] * matrixB[k][j];

            return result;
        }

        public static double[][] MatrixInverse(double[][] matrix)
        {
            int n = matrix.Length;
            double[][] result = MatrixDuplicate(matrix);

            int[] perm;
            int toggle;
            double[][] lum = MatrixDecompose(matrix, out perm,
              out toggle);
            if (lum == null)
                throw new Exception("Unable to compute inverse");

            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }

                double[] x = HelperSolve(lum, b);

                for (int j = 0; j < n; ++j)
                    result[j][i] = x[j];
            }
            return result;
        }

        public static double[][] MatrixDuplicate(double[][] matrix)
        {
            // allocates/creates a duplicate of a matrix.
            double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
            for (int i = 0; i < matrix.Length; ++i) // copy the values
                for (int j = 0; j < matrix[i].Length; ++j)
                    result[i][j] = matrix[i][j];
            return result;
        }

        public static double[] HelperSolve(double[][] luMatrix, double[] b)
        {
            // before calling this helper, permute b using the perm array
            // from MatrixDecompose that generated luMatrix
            int n = luMatrix.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum / luMatrix[i][i];
            }

            return x;
        }

        public static double[][] MatrixDecompose(double[][] matrix, out int[] perm, out int toggle)
        {
            // Doolittle LUP decomposition with partial pivoting.
            // rerturns: result is L (with 1s on diagonal) and U;
            // perm holds row permutations; toggle is +1 or -1 (even or odd)
            int rows = matrix.Length;
            int cols = matrix[0].Length; // assume square
            if (rows != cols)
                throw new Exception("Attempt to decompose a non-square m");

            int n = rows; // convenience

            double[][] result = MatrixDuplicate(matrix);

            perm = new int[n]; // set up row permutation result
            for (int i = 0; i < n; ++i) { perm[i] = i; }

            toggle = 1; // toggle tracks row swaps.
                        // +1 -greater-than even, -1 -greater-than odd. used by MatrixDeterminant

            for (int j = 0; j < n - 1; ++j) // each column
            {
                double colMax = Math.Abs(result[j][j]); // find largest val in col
                int pRow = j;
                //for (int i = j + 1; i less-than n; ++i)
                //{
                //  if (result[i][j] greater-than colMax)
                //  {
                //    colMax = result[i][j];
                //    pRow = i;
                //  }
                //}

                // reader Matt V needed this:
                for (int i = j + 1; i < n; ++i)
                {
                    if (Math.Abs(result[i][j]) > colMax)
                    {
                        colMax = Math.Abs(result[i][j]);
                        pRow = i;
                    }
                }
                // Not sure if this approach is needed always, or not.

                if (pRow != j) // if largest value not on pivot, swap rows
                {
                    double[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[pRow]; // and swap perm info
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }

                // --------------------------------------------------
                // This part added later (not in original)
                // and replaces the 'return null' below.
                // if there is a 0 on the diagonal, find a good row
                // from i = j+1 down that doesn't have
                // a 0 in column j, and swap that good row with row j
                // --------------------------------------------------

                if (result[j][j] == 0.0)
                {
                    // find a good row to swap
                    int goodRow = -1;
                    for (int row = j + 1; row < n; ++row)
                    {
                        if (result[row][j] != 0.0)
                            goodRow = row;
                    }

                    if (goodRow == -1)
                        throw new Exception("Cannot use Doolittle's method");

                    // swap rows so 0.0 no longer on diagonal
                    double[] rowPtr = result[goodRow];
                    result[goodRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[goodRow]; // and swap perm info
                    perm[goodRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }
                // --------------------------------------------------
                // if diagonal after swap is zero . .
                //if (Math.Abs(result[j][j]) less-than 1.0E-20) 
                //  return null; // consider a throw

                for (int i = j + 1; i < n; ++i)
                {
                    result[i][j] /= result[j][j];
                    for (int k = j + 1; k < n; ++k)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }


            } // main j column loop

            return result;
        }
        private static float[,] MatrixDecompose(float[,] matrix, out int[] perm, out int toggle, int n1, int m1)
        {
            // Doolittle LUP decomposition with partial pivoting.
            // rerturns: result is L (with 1s on diagonal) and U; perm holds row permutations; toggle is +1 or -1 (even or odd)
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            //Check if matrix is square
            if (rows != cols)
                throw new Exception("Attempt to MatrixDecompose a non-square mattrix");

            //float[,] result = MatrixDuplicate(matrix); // make a copy of the input matrix
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            double[][] temp = new double[n][];
            for (int i =0; i < n;i++)
            {
                temp[i] = new double[m];
            }
            for (int i =0; i < n;i++)
            {
                for (int j = 0; j < m; j ++)
                {
                    temp[i][j] = matrix[i, j];
                }
            }
            double[][] result1 = MatrixDuplicate(temp); // make a copy of the input matrix
            float[,] result = new float[n1, m1];

            for (int i = 0; i < n1; i++)
            {
                for (int j =0; j < m1; j ++)
                {
                    result[i, j] = (float)result1[i][j];
                }
            }


            perm = new int[rows]; // set up row permutation result
            for (int i = 0; i < rows; ++i) { perm[i] = i; } // i are rows counter

            toggle = 1; // toggle tracks row swaps. +1 -> even, -1 -> odd. used by MatrixDeterminant

            for (int j = 0; j < rows - 1; ++j) // each column, j is counter for coulmns
            {
                float colMax = Math.Abs(result[j, j]); // find largest value in col j
                int pRow = j;
                for (int i = j + 1; i < rows; ++i)
                {
                    if (result[i, j] > colMax)
                    {
                        colMax = result[i, j];
                        pRow = i;
                    }
                }

                if (pRow != j) // if largest value not on pivot, swap rows
                {
                    float[] rowPtr = new float[result.GetLength(1)];

                    //in order to preserve value of j new variable k for counter is declared
                    //rowPtr[] is a 1D array that contains all the elements on a single row of the matrix
                    //there has to be a loop over the columns to transfer the values
                    //from the 2D array to the 1D rowPtr array.
                    //----tranfer 2D array to 1D array BEGIN

                    for (int k = 0; k < result.GetLength(1); k++)
                    {
                        rowPtr[k] = result[pRow, k];
                    }

                    for (int k = 0; k < result.GetLength(1); k++)
                    {
                        result[pRow, k] = result[j, k];
                    }

                    for (int k = 0; k < result.GetLength(1); k++)
                    {
                        result[j, k] = rowPtr[k];
                    }

                    //----tranfer 2D array to 1D array END

                    int tmp = perm[pRow]; // and swap perm info
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }

                if (Math.Abs(result[j, j]) < 1.0E-20) // if diagonal after swap is zero . . .
                    return null; // consider a throw

                for (int i = j + 1; i < rows; ++i)
                {
                    result[i, j] /= result[j, j];
                    for (int k = j + 1; k < rows; ++k)
                    {
                        result[i, k] -= result[i, j] * result[j, k];
                    }
                }
            } // main j column loop

            return result;
        }



    }
}
