public class SelectedTank
{
    public readonly int Player;
    public readonly TypeAction Action;
    public readonly int Selected;

    public SelectedTank(int player, TypeAction action, int selected)
    {
        Player = player;
        Action = action;
        Selected = selected;
    }
    public SelectedTank(int player, TypeAction action)
    {
        Player = player;
        Action = action;
    }
}
