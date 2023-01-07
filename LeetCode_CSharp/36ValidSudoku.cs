namespace LeetCode.CSharp;

public class ValidSudoku
{
    public void Test()
    {
        char[][] board = new[]
        {
            new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
            new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
        };

        Console.WriteLine($"Is it a valid Sudoku? {IsValidSudoku(board)}");
    }

    public bool IsValidSudoku(char[][] board)
    {
        if (!IsRowValid(board))
            return false;
        if (!IsColumnValid(board))
            return false;
        if (!IsBlockValid(board))
            return false;

        return true;
    }

    private bool IsRowValid(char[][] board)
    {

        foreach (var row in board)
        {
            var hm = new Dictionary<char, int>();
            foreach (var num in row)
            {
                if (num == '.') continue;

                if (hm.TryGetValue(num, out var count))
                {
                    if (count == 1) return false;
                }

                hm[num] = 1;
            }
        }

        return true;
    }

    private bool IsColumnValid(char[][] board)
    {
        for (int i = 0; i < board[0].Length; i++)
        {
            var hm = new Dictionary<char, int>();
            foreach (var row in board)
            {
                if (row[i] == '.') continue;

                if (hm.TryGetValue(row[i], out var count))
                {
                    if (count == 1) return false;
                }

                hm[row[i]] = 1;
            }
        }

        return true;
    }

    // 9 blocks in total.
    private bool IsBlockValid(char[][] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var hm = new Dictionary<char, int>();
                var block = new List<char>();
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        block.Add(board[row + i * 3][col + j * 3]);
                    }
                }

                foreach (var num in block)
                {
                    if (num == '.') continue;

                    if (hm.TryGetValue(num, out var count))
                    {
                        if (count == 1) return false;
                    }

                    hm[num] = 1;
                }
            }
        }

        return true;
    }
}