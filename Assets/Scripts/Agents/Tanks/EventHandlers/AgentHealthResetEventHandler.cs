using UnityEngine;

public class AgentHealthResetEventHandler : MonoBehaviour, IObserver<StartRoundEventArgs>
{
    private GameController gameController;
    private IResetHealth healthReset;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();

        healthReset = GetComponent<IResetHealth>();
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
        ResetHealth();
    }

    private void ResetHealth()
    {
        healthReset.ResetHealth();
    }
}