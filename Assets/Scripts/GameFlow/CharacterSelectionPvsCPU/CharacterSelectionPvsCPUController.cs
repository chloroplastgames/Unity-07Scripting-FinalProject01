using UnityEngine;

public class CharacterSelectionPvsCPUController : MonoBehaviour, ICharacterSelectionPvsCPU, ICharacterSelectionPvsCPUEvents
{
    public ISubject<Player1CharacterSelectionEventArgs> Player1CharacterSelectorSubject => player1CharacterSelectorSubject;
    public ISubject<CancelEventArgs> CancelCharacterSelectionSubject => cancelCharacterSelectionSubject;

    public GameObject CanvasCharacterSelectionPvsCPU => canvasCharacterSelectionPvsCPU;

    [SerializeField] private GameObject canvasCharacterSelectionPvsCPU;
    [SerializeField] private PlayerControlData player1Control;

    private IPlayerCharacterSelection player1CharacterSelector;
    private CancelCharacterSelectionBehaviour cancelCharacterSelectionBehaviour;

    private ISubject<Player1CharacterSelectionEventArgs> player1CharacterSelectorSubject;
    private ISubject<CancelEventArgs> cancelCharacterSelectionSubject;

    private void Awake()
    {
        player1CharacterSelector = GetComponent<Player1CharacterSelectionBehaviour>();
        cancelCharacterSelectionBehaviour = GetComponent<CancelCharacterSelectionBehaviour>();

        player1CharacterSelectorSubject = GetComponent<Player1CharacterSelectionBehaviour>();
        cancelCharacterSelectionSubject = GetComponent<CancelCharacterSelectionBehaviour>();
    }

    public void GetPlayer1Input()
    {
        if (Input.GetKeyDown(player1Control.TurnLeft))
        {
            player1CharacterSelector.PreviousSelection();
        }
        else if (Input.GetKeyDown(player1Control.TurnRight))
        {
            player1CharacterSelector.NextSelection();
        }
        else if (Input.GetKeyDown(player1Control.Shoot))
        {
            player1CharacterSelector.SetSelection();
        }
        else if (Input.GetKeyDown(player1Control.Special))
        {
            cancelCharacterSelectionBehaviour.CancelSelection();
        }
    }

    public void ResetPlayer1Selection()
    {
        player1CharacterSelector.ResetSelection();
    }
}