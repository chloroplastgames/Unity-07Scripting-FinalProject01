using UnityEngine;
using UnityEngine.UI;

public class CountdownBehaviour : Subject<CountdownArgs>, IStartCountdown
{
    [SerializeField] private Text countdownText;

    private const int CountdownTime = 3;

    private int time;

    public void StartCountdown()
    {
        time = CountdownTime;

        Countdown(time);
    }

    public override void Notify()
    {
        IObserver<CountdownArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<CountdownArgs> observer in observersPhoto)
        {
            observer.OnNotify(new CountdownArgs());
        }
    }

    private void Countdown(int time)
    {
        if (time == 0)
        {
            Notify();
            return;
        }

        countdownText.text = time.ToString();
        time--;

        CoroutinesHelperSingleton.Instance.WaitForSeconds(1f, () => Countdown(time));
    }
}