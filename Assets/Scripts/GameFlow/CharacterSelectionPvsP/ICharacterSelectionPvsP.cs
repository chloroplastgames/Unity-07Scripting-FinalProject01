using UnityEngine;

public interface ICharacterSelectionPvsP
{
    GameObject CanvasCharacterSelectionPvsP { get; }
    void GetPlayer1Input();
    void GetPlayer2Input();
    void ResetPlayer1Selection();
    void ResetPlayer2Selection();
    ISubject<Player1CharacterSelectionArgs> Player1CharacterSelectorSubject { get; }
    ISubject<Player2CharacterSelectionArgs> Player2CharacterSelectorSubject { get; }
}