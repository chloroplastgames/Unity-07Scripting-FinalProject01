public interface ISubject<T>
{
    void Register(IObserver<T> Observer);

    void Remove(IObserver<T> Observer);

    void UpdateObservers(T mensage);
}
