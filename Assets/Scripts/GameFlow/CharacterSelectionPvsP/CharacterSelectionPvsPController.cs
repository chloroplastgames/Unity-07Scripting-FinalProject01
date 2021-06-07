using UnityEngine;

public class CharacterSelectionPvsPController : MonoBehaviour, ICharacterSelectionPvsP, ICharacterSelectionPvsPEvents
{
    public ISubject<Player1CharacterSelectionEventArgs> Player1CharacterSelectorSubject => player1CharacterSelectorSubject;
    public ISubject<Player2CharacterSelectionEventArgs> Player2CharacterSelectorSubject => player2CharacterSelectorSubject;
    public ISubject<CancelEventArgs> CancelCharacterSelectionSubject => cancelCharacterSelectionSubject;

    public GameObject CanvasCharacterSelectionPvsP => canvasCharacterSelectionPvsP;

    [SerializeField] private GameObject canvasCharacterSelectionPvsP;
    [SerializeField] private PlayerControlData player1Control;
    [SerializeField] private PlayerControlData player2Control;

    private IPlayerCharacterSelection player1CharacterSelector;
    private IPlayerCharacterSelection player2CharacterSelector;
    private CancelCharacterSelectionBehaviour cancelCharacterSelectionBehaviour;

    private ISubject<Player1CharacterSelectionEventArgs> player1CharacterSelectorSubject;
    private ISubject<Player2CharacterSelectionEventArgs> player2CharacterSelectorSubject;
    private ISubject<CancelEventArgs> cancelCharacterSelectionSubject;

    private void Awake()
    {
        player1CharacterSelector = GetComponent<Player1CharacterSelectionBehaviour>();
        player2CharacterSelector = GetComponent<Player2CharacterSelectionBehaviour>();
        cancelCharacterSelectionBehaviour = GetComponent<CancelCharacterSelectionBehaviour>();

        player1CharacterSelectorSubject = GetComponent<Player1CharacterSelectionBehaviour>();
        player2CharacterSelectorSubject = GetComponent<Player2CharacterSelectionBehaviour>();
        cancelCharacterSelectionSubject = GetComponent<CancelCharacterSelectionBehaviour>();
    }

    private void Start()
    {
        canvasCharacterSelectionPvsP.SetActive(false);
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

    public void GetPlayer2Input()
    {
        if (Input.GetKeyDown(player2Control.TurnLeft))
        {
            player2CharacterSelector.PreviousSelection();
        }
        else if (Input.GetKeyDown(player2Control.TurnRight))
        {
            player2CharacterSelector.NextSelection();
        }
        else if (Input.GetKeyDown(player2Control.Shoot))
        {
            player2CharacterSelector.SetSelection();
        }
        else if (Input.GetKeyDown(player2Control.Special))
        {
            cancelCharacterSelectionBehaviour.CancelSelection();
        }
    }

    public void ResetPlayer1Selection()
    {
        player1CharacterSelector.ResetSelection();
    }

    public void ResetPlayer2Selection()
    {
        player2CharacterSelector.ResetSelection();
    }
}