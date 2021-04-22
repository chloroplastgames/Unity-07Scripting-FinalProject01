public interface IObserver
{
    ISubject Subject { get; }
    void OnNotify();
}

public interface IObserver<T>
{
    ISubject<T> Subject { get; }
    void OnNotify(T parameter);
}