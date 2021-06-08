using UnityEngine;

public interface IMainMenu
{
    ISubject<ButtonPvsPEventArgs> ButtonPvsPSubject { get; }
    ISubject<ButtonPvsCPUEventArgs> ButtonPvsCPUSubject { get; }
    GameObject CanvasMainMenu { get; }
}