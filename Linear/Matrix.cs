using System.Runtime.InteropServices;

namespace Linear
{
    public class Matrix
    {

        private float[,] data;

        public Matrix(float[,] A)
        {

            data = new float[A.GetLength(1), A.GetLength(0)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    data[j,i] = A[i, j];
                }
            }
        }

        public override String ToString() 
        {
            String s = "";

            for (int i = 0; i < data.GetLength(1); i++)
            {
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    s += String.Format("{0:f2} \t", data[j, i]);
                }
                s += "\n";
            }

            return s;
        }

        [DllImport("lapack.dll", CallingConvention=CallingConvention.Cdecl)]
        public static extern void sgesv_dotnet(ref int n, ref int nrhs, float[,] a, ref int lda, int[] ipiv, float[,] b, ref int ldb, ref int info);
    
        public static float[,] matMul(float[,] A, float[,] b)
        {

            int N = b.GetLength(1);
            int NRHS = b.GetLength(0);

            if (A.GetLength(0) != N || A.GetLength(1) != N)
            {
                throw new ArgumentException("Matrix A does not have the correct shape!");
            }

            // Create ipiv, and info
            int[] ipiv = new int[N];
            int info = 0;

            // Copy A and b
            float[,] A_lapack = (float[,]) A.Clone();
            float[,] b_lapack = (float[,]) b.Clone();

            // Call LAPACK routine
            Matrix.sgesv_dotnet(ref N, ref NRHS, A_lapack, ref N, ipiv, b_lapack, ref N, ref info);

            if (info != 0)
            {
                throw new ArithmeticException("Error in solving linear system!");
            }

            return b_lapack;
        }
    
    }
}
