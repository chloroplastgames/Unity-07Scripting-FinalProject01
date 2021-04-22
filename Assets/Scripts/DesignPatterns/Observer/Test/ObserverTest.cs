public class ObserverTest : Observer
{
    public override ISubject Subject
    {
        get => subject;
        protected set => subject = value;
    }

    private ISubject subject;

    private void Awake()
    {
        subject = GetComponent<ISubject>();
    }

    public override void OnNotify()
    {
        print("Notified!");
    }
}