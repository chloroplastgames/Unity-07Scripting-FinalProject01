using UnityEngine;

public interface IHUD
{
    GameObject CanvasHUD { get; }
    void ResetTimer();
    void StopTimer();
    void StartTimer();
    ISubject<TimerArgs> TimerSubject { get; }
}