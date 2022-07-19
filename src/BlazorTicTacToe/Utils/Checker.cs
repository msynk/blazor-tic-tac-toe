namespace BlazorTicTacToe.Utils;

public static class Checker
{
    private readonly static int[][][] WIN_LINES =
    {
        new int[][] { new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 0, 2 } },
        new int[][] { new int[] { 1, 0 }, new int[] { 1, 1 }, new int[] { 1, 2 } },
        new int[][] { new int[] { 2, 0 }, new int[] { 2, 1 }, new int[] { 2, 2 } },

        new int[][] { new int[] { 0, 0 }, new int[] { 1, 0 }, new int[] { 2, 0 } },
        new int[][] { new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 2, 1 } },
        new int[][] { new int[] { 0, 2 }, new int[] { 1, 2 }, new int[] { 2, 2 } },

        new int[][] { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 2 } },
        new int[][] { new int[] { 0, 2 }, new int[] { 1, 1 }, new int[] { 2, 0 } }
    };

    private const string P1 = Players.P1;
    private const string P2 = Players.P2;

    public static WinResult? CheckBoard(string[][] board)
    {
        var (p1s, p2s) = ExtractPlayers(board);

        for (int i = 0; i < WIN_LINES.Length; i++)
        {
            var line = WIN_LINES[i];

            if (CheckWinner(line, p1s)) return new WinResult { Player = P1, Line = line };
            if (CheckWinner(line, p2s)) return new WinResult { Player = P2, Line = line };
        }
        return null;
    }

    private static bool CheckWinner(int[][] line, List<int[]> ps) => line.All(lineCell =>
    {
        for (int idx = 0; idx < ps.Count; idx++)
        {
            var pCell = ps[idx];
            if (pCell[0] == lineCell[0] && pCell[1] == lineCell[1])
            {
                return true;
            }
        }
        return false;
    });

    private static (List<int[]>, List<int[]>) ExtractPlayers(string[][] board)
    {
        var p1s = new List<int[]>();
        var p2s = new List<int[]>();

        for (int i = 0; i < board.Length; i++)
        {
            var row = board[i];
            for (int j = 0; j < row.Length; j++)
            {
                var col = row[j];
                if (col == P1)
                {
                    p1s.Add(new int[] { i, j });
                }
                else if (col == P2)
                {
                    p2s.Add(new int[] { i, j });
                }
            }
        }

        return (p1s, p2s);
    }
}
