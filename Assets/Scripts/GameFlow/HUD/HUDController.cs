using UnityEngine;

public class HUDController : MonoBehaviour, IHUD, IHUDEvents
{
    public ISubject<TimerEventArgs> TimerSubject => timerSubject;

    public GameObject CanvasHUD => canvasHUD;

    [SerializeField] private GameObject canvasHUD;

    private ITimer timer;

    private ISubject<TimerEventArgs> timerSubject;

    private void Awake()
    {
        timer = GetComponent<ITimer>();

        timerSubject = GetComponent<ISubject<TimerEventArgs>>();
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
}