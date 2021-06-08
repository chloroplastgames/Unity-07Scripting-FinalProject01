public interface IGameOverEvents
{
    ISubject<ButtonRestartEventArgs> ButtonRestartSubject { get; }
}