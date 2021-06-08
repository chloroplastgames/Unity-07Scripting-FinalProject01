public interface ISubject
{
    void Add(IObserver observer);
    void Remove(IObserver observer);
    void Notify();
}

public interface ISubject<T>
{
    void Add(IObserver<T> observer);
    void Remove(IObserver<T> observer);
    void Notify();
}