using UnityEngine;

public class CountdownController : MonoBehaviour, ICountdown, ICountdownEvents
{
    public ISubject<CountdownEventArgs> CounterSubject => counterSubject;

    public GameObject CanvasCountdown => canvasCountdown;

    [SerializeField] private GameObject canvasCountdown;

    private IStartCountdown counter;

    private ISubject<CountdownEventArgs> counterSubject;

    private void Awake()
    {
        counter = GetComponent<IStartCountdown>();

        counterSubject = GetComponent<ISubject<CountdownEventArgs>>();
    }

    public void StartCountdown()
    {
        counter.StartCountdown();
    }
}