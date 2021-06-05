public interface IMainMenuEvents
{
    ISubject<ButtonPvsPArgs> ButtonPvsPSubject { get; }
    ISubject<ButtonPvsCPUArgs> ButtonPvsCPUSubject { get; }
}