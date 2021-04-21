using UnityEngine;

public class SubjectTest : Subject
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Notify();
        }
    }

    public override void Notify()
    {
        foreach (Observer observer in observers)
        {
            observer.OnNotify();
        }
    }
}