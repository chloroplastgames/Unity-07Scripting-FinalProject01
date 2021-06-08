public interface ICountdownEvents
{
    ISubject<CountdownEventArgs> CounterSubject { get; }
}