using UnityEngine;

public abstract class PointResetEventHandlerBase : MonoBehaviour, IObserver<StartRoundEventArgs>
{
    protected GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        gameController.StartRoundSubject.Add(this);
    }

    private void OnDisable()
    {
        gameController.StartRoundSubject.Remove(this);
    }

    public void OnNotify(StartRoundEventArgs parameter)
    {
        ResetPoint();
    }

    protected abstract void ResetPoint();
}