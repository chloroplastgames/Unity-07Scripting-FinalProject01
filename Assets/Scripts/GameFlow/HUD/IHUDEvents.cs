public interface IHUDEvents
{
    ISubject<TimerEventArgs> TimerSubject { get; }
}