void PrintMatrix(int[][] matrix)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix.Length; j++)
        {
            Console.Write(matrix[i][j] + " ");
        }
        Console.WriteLine();
    }
}

void Rotate(int[][] matrix)
{
    Array.Reverse(matrix);

    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix.Length; j++)
        {
            if (i < j)
            {
                (matrix[j][i], matrix[i][j]) = (matrix[i][j], matrix[j][i]);
            }
        }
    }
}

Console.WriteLine("Input:");
int[][] matrix =
[
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
];
PrintMatrix(matrix);
Rotate(matrix);
Console.WriteLine("Output:");
PrintMatrix(matrix);
