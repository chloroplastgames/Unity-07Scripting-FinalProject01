public class DieBehaviour : Subject, IKillable
{
    public void Kill()
    {
        Notify();
    }

    public override void Notify()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            IObserver observer = observers[i];
            observer.OnNotify();
        }
    }
}