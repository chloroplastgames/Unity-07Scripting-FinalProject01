public interface IMainMenuEvents
{
    ISubject<ButtonPvsPEventArgs> ButtonPvsPSubject { get; }
    ISubject<ButtonPvsCPUEventArgs> ButtonPvsCPUSubject { get; }
}