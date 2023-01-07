namespace LeetCode.CSharp;

public class RotateImage
{
    public void Test()
    {
        var matrix = new[]
        {
            new[] { 1, 2, 3 },
            new[] { 4, 5, 6 },
            new[] { 7, 8, 9 },
        };

        var res = Rotate(matrix);
    }

    public int[][] Rotate(int[][] matrix)
    {
        // Rotate the matrix clock-wise 90 degree, 
        // equals flip Diagonal then flip vertical.
        // i.e.  swap num[i,j] to num[j,i], than swap n[i, j] with num[^i, j].

        // diagonal flip
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = i; j < matrix[0].Length; j++)
            {
                (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            }
        }

        // vertical flip
        foreach (var row in matrix)
        {
            for (int j = 0; j < matrix[0].Length / 2; j++)
            {
                (row[j], row[^(j + 1)]) = (row[^(j + 1)], row[j]);
            }
        }

        matrix.ToList().ForEach(r => Console.WriteLine(string.Join(",", r)));
        return matrix;
    }
}