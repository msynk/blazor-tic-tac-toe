namespace BlazorTicTacToe.Utils;

public class WinResult
{
    public string Player { get; set; } = default!;
    public int[][] Line { get; set; } = default!;
}
