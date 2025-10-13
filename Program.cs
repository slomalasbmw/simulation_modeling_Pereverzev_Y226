using System;

class MatrixMultiplication
{
    static void Main(string[] args)
    {
        double[,] matrixA =
        {
            {1, 2, 3},
            {4, 5, 6}
        };

        double[,] matrixB =
        {
            {7, 8},
            {9, 10},
            {11, 12}
        };

        Console.WriteLine("Матрица A:");
        PrintMatriix(matrixA);
        Console.WriteLine("Матрица B:");
        PrintMatriix(matrixB);

        try
        {
            double[,] result = MultiplyMatrices(matrixA, matrixB);
            Console.WriteLine("\nРезультат умножения A x B:");
            PrintMatriix(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    public static double[,] MultiplyMatrices(double[,] matrixA, double[,] matrixB)
    {
        if (matrixA == null || matrixB == null)
            throw new ArgumentNullException("Обе матрицы должны быть не null");

        int aRows = matrixA.GetLength(0);
        int aCols = matrixA.GetLength(1);
        int bRows = matrixB.GetLength(0);
        int bCols = matrixB.GetLength(1);

        if (aCols != bRows)
            throw new ArgumentException($"Невозможно умножить матрицы: число столбцов первой матрицы ({aCols}) " +
                $"не совпадает с числом строк второй матрицы ({bRows})");

        double[,] result = new double[aRows, bCols];

        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j< bCols; j++)
            {
                double sum = 0;
                for (int k = 0; k < aCols; k++)
                {
                    sum += matrixA[i, k] * matrixB[k, j];
                }
                result[i, j] = sum;
            }
        }

        return result;
    }

    public static void PrintMatriix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows;i++)
        {
            for(int j = 0;j< cols; j++)
            {
                Console.Write(matrix[i, j].ToString().PadLeft(8) + " ");
            }
            Console.WriteLine();
        }
    }
}