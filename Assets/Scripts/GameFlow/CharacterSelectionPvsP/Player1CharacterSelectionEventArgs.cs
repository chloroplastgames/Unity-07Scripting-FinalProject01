using UnityEngine;

public struct Player1CharacterSelectionEventArgs
{
    public readonly Color player1Color;

    public Player1CharacterSelectionEventArgs(Color player1Color)
    {
        this.player1Color = player1Color;
    }
}