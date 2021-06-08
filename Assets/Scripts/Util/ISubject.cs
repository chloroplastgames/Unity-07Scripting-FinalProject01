public interface ISubject<T>
{
    void Register(IObserver<T> Observer);

    void Remove(IObserver<T> Observer);

    void UpdateObservers(T mensage);
}

public interface ISubject<T,Q>
{
    void Register(IObserver<T,Q> Observer);

    void Remove(IObserver<T,Q> Observer);

    void UpdateObservers(T mensage, Q mensage02);
}

