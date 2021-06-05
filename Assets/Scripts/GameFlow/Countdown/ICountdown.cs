using UnityEngine;

public interface ICountdown
{
    GameObject CanvasCountdown { get; }
    void StartCountdown();
    ISubject<CountdownArgs> CounterSubject { get; }
}