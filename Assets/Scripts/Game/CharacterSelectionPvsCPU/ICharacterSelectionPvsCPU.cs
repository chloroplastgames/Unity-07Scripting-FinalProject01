using UnityEngine;

public interface ICharacterSelectionPvsCPU
{
    GameObject CanvasCharacterSelectionPvsCPU { get; }
    void GetPlayer1Input();
    void ResetPlayer1Selection();
    ISubject<Player1CharacterSelectionArgs> Player1CharacterSelectorSubject { get; }
}