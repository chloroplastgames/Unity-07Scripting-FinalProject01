public interface IObserver
{
    void InitializeSubject();
    void OnNotify();
}

public interface IObserver<T>
{
    void InitializeSubject();
    void OnNotify(T parameter);
}