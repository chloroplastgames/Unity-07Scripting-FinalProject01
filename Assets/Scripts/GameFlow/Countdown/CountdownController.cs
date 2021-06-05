using UnityEngine;

public class CountdownController : MonoBehaviour, ICountdown, ICountdownEvents
{
    public ISubject<CountdownArgs> CounterSubject => counterSubject;

    public GameObject CanvasCountdown => canvasCountdown;

    [SerializeField] private GameObject canvasCountdown;

    private IStartCountdown counter;

    private ISubject<CountdownArgs> counterSubject;

    private void Awake()
    {
        counter = GetComponent<IStartCountdown>();

        counterSubject = GetComponent<ISubject<CountdownArgs>>();
    }

    public void StartCountdown()
    {
        counter.StartCountdown();
    }
}