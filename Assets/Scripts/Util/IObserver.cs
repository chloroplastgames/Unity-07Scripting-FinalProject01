public interface IObserver<T>
{
    void Notify(T mensage);
}

public interface IObserver<T,Q>
{
    void Notify(T mensage, Q mensage02);
}
