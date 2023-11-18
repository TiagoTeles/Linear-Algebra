using Linear;

class Program
{
       static void Main(string[] args)
    {
        float[,] a = new float[,]
        {
            {1.0f, 1.0f},
            {0.0f, 1.0f},
        };

        float[,] b = new float[,]
        {
            {1.0f, 4.0f},
        };

        float[,] x = Matrix.matMul(a, b);

        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine(x[0, i]);
        }

        float[,] tt = new float[,] {{1.0f, 1.0f}, {0.0f, 1.0f}}; 

        Matrix test = new Matrix(tt);

        Console.WriteLine(test);

    }
}