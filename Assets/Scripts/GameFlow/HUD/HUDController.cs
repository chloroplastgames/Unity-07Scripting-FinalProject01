using UnityEngine;

public class HUDController : MonoBehaviour, IHUD, IHUDEvents, IHUDSetup
{
    public ISubject<TimerArgs> TimerSubject => timerSubject;

    public GameObject CanvasHUD => canvasHUD;

    [SerializeField] private GameObject canvasHUD;

    private ITimer timer;
    private ISetupHealthHUD leftHealthHUD;
    private ISetupHealthHUD rightHealthHUD;

    private ISubject<TimerArgs> timerSubject;

    private void Awake()
    {
        timer = GetComponent<ITimer>();
        leftHealthHUD = GetComponent<LeftHealthHUDBehaviour>();
        rightHealthHUD = GetComponent<RightHealthHUDBehaviour>();

        timerSubject = GetComponent<ISubject<TimerArgs>>();
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

    public void SetupLeftHealthHUD(ISubject<HealthChangedArgs> healthSubject)
    {
        leftHealthHUD.Setup(healthSubject);
    }

    public void SetupRightHealthHUD(ISubject<HealthChangedArgs> healthSubject)
    {
        rightHealthHUD.Setup(healthSubject);
    }
}