using UnityEngine;

public class HUDController : MonoBehaviour, IHUD, IHUDEvents,
    IObserver<Player1CharacterSelectionEventArgs>, IObserver<Player2CharacterSelectionEventArgs>
{
    public ISubject<TimerEventArgs> TimerSubject => timerSubject;

    public GameObject CanvasHUD => canvasHUD;

    [SerializeField] private GameObject canvasHUD;

    private ITimer timer;
    private LeftBackgroundHUDBehaviour leftBackgroundHUDBehaviour;
    private RightBackgroundHUDBehaviour rightBackgroundHUDBehaviour;

    private ICharacterSelectionPvsPEvents characterSelectionPvsPEvents;
    private ICharacterSelectionPvsCPUEvents characterSelectionPvsCPUEvents;

    private ISubject<TimerEventArgs> timerSubject;

    private void Awake()
    {
        timer = GetComponent<ITimer>();
        leftBackgroundHUDBehaviour = GetComponent<LeftBackgroundHUDBehaviour>();
        rightBackgroundHUDBehaviour = GetComponent<RightBackgroundHUDBehaviour>();

        characterSelectionPvsPEvents = FindObjectOfType<CharacterSelectionPvsPController>();
        characterSelectionPvsCPUEvents = FindObjectOfType<CharacterSelectionPvsCPUController>();

        timerSubject = GetComponent<ISubject<TimerEventArgs>>();
    }

    private void Start()
    {
        canvasHUD.SetActive(false);

        characterSelectionPvsPEvents.Player1CharacterSelectorSubject.Add(this);
        characterSelectionPvsPEvents.Player2CharacterSelectorSubject.Add(this);

        characterSelectionPvsCPUEvents.Player1CharacterSelectorSubject.Add(this);
    }

    private void OnDestroy()
    {
        characterSelectionPvsPEvents.Player1CharacterSelectorSubject?.Remove(this);
        characterSelectionPvsPEvents.Player2CharacterSelectorSubject?.Remove(this);

        characterSelectionPvsCPUEvents.Player1CharacterSelectorSubject?.Remove(this);
    }

    public void ResetTimer()
    {
        timer.ResetTimer();
    }

    public void StopTimer()
    {
        timer.StopTimer();
    }

    public void StartTimer()
    {
        timer.StartTimer();
    }

    public void OnNotify(Player1CharacterSelectionEventArgs player1CharacterSelectionEventArgs)
    {
        leftBackgroundHUDBehaviour.ChangeBackgroundColor(player1CharacterSelectionEventArgs.player1Color);
    }
    public void OnNotify(Player2CharacterSelectionEventArgs player2CharacterSelectionEventArgs)
    {
        rightBackgroundHUDBehaviour.ChangeBackgroundColor(player2CharacterSelectionEventArgs.player2Color);
    }
}