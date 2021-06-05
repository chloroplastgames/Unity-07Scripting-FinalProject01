using UnityEngine;
using UnityEngine.UI;

public class LeftBackgroundHUDBehaviour : MonoBehaviour, IObserver<Player1CharacterSelectionArgs>
{
    [SerializeField] protected RawImage background;

    private ICharacterSelectionPvsPEvents characterSelectionPvsPEvents;
    private ICharacterSelectionPvsCPUEvents characterSelectionPvsCPUEvents;

    private void Awake()
    {
        characterSelectionPvsPEvents = FindObjectOfType<CharacterSelectionPvsPController>();
        characterSelectionPvsCPUEvents = FindObjectOfType<CharacterSelectionPvsCPUController>();
    }

    private void Start()
    {
        characterSelectionPvsPEvents.Player1CharacterSelectorSubject.Add(this);
        characterSelectionPvsCPUEvents.Player1CharacterSelectorSubject.Add(this);
    }

    private void OnDisable()
    {
        characterSelectionPvsPEvents.Player1CharacterSelectorSubject.Remove(this);
        characterSelectionPvsCPUEvents.Player1CharacterSelectorSubject.Remove(this);
    }

    public void OnNotify(Player1CharacterSelectionArgs player1CharacterSelectionArgs)
    {
        background.color = player1CharacterSelectionArgs.player1Color;
    }
}