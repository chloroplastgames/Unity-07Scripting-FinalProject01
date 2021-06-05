using UnityEngine;

public interface ICountdown
{
    GameObject CanvasCountdown { get; }
    void StartCountdown();
    ISubject<CountdownEventArgs> CounterSubject { get; }
}