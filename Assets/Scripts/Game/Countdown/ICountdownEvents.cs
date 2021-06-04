public interface ICountdownEvents
{
    ISubject<CountdownArgs> CounterSubject { get; }
}