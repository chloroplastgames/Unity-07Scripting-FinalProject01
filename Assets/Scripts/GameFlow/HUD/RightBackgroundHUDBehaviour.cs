using UnityEngine;
using UnityEngine.UI;

public class RightBackgroundHUDBehaviour : MonoBehaviour, IObserver<Player2CharacterSelectionArgs>
{
    [SerializeField] protected RawImage background;

    private ICharacterSelectionPvsPEvents characterSelectionPvsPEvents;

    private void Awake()
    {
        characterSelectionPvsPEvents = FindObjectOfType<CharacterSelectionPvsPController>();
    }

    private void Start()
    {
        characterSelectionPvsPEvents.Player2CharacterSelectorSubject.Add(this);
    }

    private void OnDisable()
    {
        characterSelectionPvsPEvents.Player2CharacterSelectorSubject.Remove(this);
    }

    public void OnNotify(Player2CharacterSelectionArgs player2CharacterSelectionArgs)
    {
        background.color = player2CharacterSelectionArgs.player2Color;
    }
}