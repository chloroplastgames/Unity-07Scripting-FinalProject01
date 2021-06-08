using UnityEngine;

/// <summary>
/// Handler to reset the position of the agent when the round ends
/// </summary>

public abstract class PointResetEventHandlerBase : MonoBehaviour, IObserver<EndRoundEventArgs>
{
    [SerializeField] protected GameObject leftDustTrail;
    [SerializeField] protected GameObject rightDustTrail;

    // TODO: interface
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