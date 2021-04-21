public class ObserverTest : Observer
{
    public override void InitializeSubject()
    {
        subject = GetComponent<SubjectTest>();
    }

    public override void OnNotify()
    {
        print("Notified");
    }
}