using UnityEngine;

public struct Player2CharacterSelectionEventArgs
{
    public readonly Color player2Color;

    public Player2CharacterSelectionEventArgs(Color player2Color)
    {
        this.player2Color = player2Color;
    }
}