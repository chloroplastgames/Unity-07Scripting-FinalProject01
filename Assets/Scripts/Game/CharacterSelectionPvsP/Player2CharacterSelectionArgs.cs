using UnityEngine;

public struct Player2CharacterSelectionArgs
{
    public readonly Color player2Color;

    public Player2CharacterSelectionArgs(Color player2Color)
    {
        this.player2Color = player2Color;
    }
}