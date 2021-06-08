using UnityEngine;
using UnityEngine.UI;

public class TimerHUDBehaviour : Subject<TimerEventArgs>, ITimer
{
    [SerializeField] private Text timerText;
    [SerializeField] private float time;

    private float timeRemaining;
    private bool timerIsRunning;

    private void Update()
    {
        if (!timerIsRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0f;
            timerIsRunning = false;

            Notify();
        }
    }

    public void ResetTimer()
    {
        timeRemaining = time;
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public override void Notify()
    {
        IObserver<TimerEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<TimerEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new TimerEventArgs());
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}