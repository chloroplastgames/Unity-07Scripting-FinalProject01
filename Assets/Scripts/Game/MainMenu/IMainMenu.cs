using UnityEngine;

public interface IMainMenu
{
    ISubject<ButtonPvsPArgs> ButtonPvsPSubject { get; }
    ISubject<ButtonPvsCPUArgs> ButtonPvsCPUSubject { get; }
    GameObject CanvasMainMenu { get; }
}