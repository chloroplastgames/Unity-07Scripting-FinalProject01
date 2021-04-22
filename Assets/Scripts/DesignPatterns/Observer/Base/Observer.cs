using UnityEngine;

public abstract class Observer : MonoBehaviour, IObserver
{
    public abstract ISubject Subject { get; protected set; }

    private void OnEnable()
    {
        Subject.Add(this);
    }

    private void OnDisable()
    {
        Subject.Remove(this);
    }

    public abstract void OnNotify();
}

public abstract class Observer<T> : MonoBehaviour, IObserver<T>
{
    public abstract ISubject<T> Subject { get; protected set; }

    protected void OnEnable()
    {
        Subject.Add(this);
    }

    protected void OnDisable()
    {
        Subject.Remove(this);
    }

    public abstract void OnNotify(T parameter);
}