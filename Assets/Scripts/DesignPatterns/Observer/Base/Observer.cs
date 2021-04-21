// TODO: Get rid of the interfaces and apply encapsulation

using UnityEngine;

public abstract class Observer : MonoBehaviour, IObserver
{
    protected ISubject subject;

    private void Awake()
    {
        InitializeSubject();
    }

    private void OnEnable()
    {
        subject.Add(this);
    }

    private void OnDisable()
    {
        subject.Remove(this);
    }

    public abstract void InitializeSubject();

    public abstract void OnNotify();
}

public abstract class Observer<T> : MonoBehaviour, IObserver<T>
{
    protected ISubject<T> subject;

    private void Awake()
    {
        InitializeSubject();
    }

    private void OnEnable()
    {
        subject.Add(this);
    }

    private void OnDisable()
    {
        subject.Remove(this);
    }

    public abstract void InitializeSubject();

    public abstract void OnNotify(T parameter);
}