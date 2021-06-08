using UnityEngine;

public abstract class PointResetEventHandlerBase : MonoBehaviour, IObserver<EndRoundEventArgs>
{
    [SerializeField] protected GameObject leftDustTrail;
    [SerializeField] protected GameObject rightDustTrail;

    protected GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        gameController.EndRoundSubject.Add(this);
    }

    private void OnDisable()
    {
        gameController.EndRoundSubject.Remove(this);
    }

    public void OnNotify(EndRoundEventArgs parameter)
    {
        ResetPoint();
    }

    protected abstract void ResetPoint();
}