using UnityEngine;
using UnityEngine.UI;

public class TimerHUDBehaviour : Subject<TimerArgs>
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

    public override void Notify()
    {
        IObserver<TimerArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<TimerArgs> observer in observersPhoto)
        {
            observer.OnNotify(new TimerArgs());
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

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}