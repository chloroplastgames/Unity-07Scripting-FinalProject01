using UnityEngine;

public interface IGameOver
{
    ISubject<ButtonRestartEventArgs> ButtonRestartSubject { get; }
    GameObject CanvasGameOver { get; }
}
