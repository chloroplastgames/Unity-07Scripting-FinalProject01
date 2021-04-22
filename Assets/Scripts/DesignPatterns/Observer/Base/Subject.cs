using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour, ISubject
{
    protected readonly List<IObserver> observers = new List<IObserver>();

    public void Add(IObserver observer)
    {
        if (observers.Contains(observer)) return;

        observers.Add(observer);
    }

    public void Remove(IObserver observer)
    {
        if (!observers.Contains(observer)) return;

        observers.Remove(observer);
    }

    public void Notify()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            Observer observer = (Observer)observers[i];
            observer.OnNotify();
        }
    }
}

public abstract class Subject<T> : MonoBehaviour, ISubject<T>
{
    protected readonly List<IObserver<T>> observers = new List<IObserver<T>>();

    public void Add(IObserver<T> observer)
    {
        if (observers.Contains(observer)) return;

        observers.Add(observer);
    }

    public void Remove(IObserver<T> observer)
    {
        if (!observers.Contains(observer)) return;

        observers.Remove(observer);
    }

    public void Notify()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            Observer observer = (Observer)observers[i];
            observer.OnNotify();
        }
    }
}