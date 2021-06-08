public struct GameWinnerEventArgs
{
    public readonly GameWinner gameWinner;

    public GameWinnerEventArgs(GameWinner gameWinner)
    {
        this.gameWinner = gameWinner;
    }
}