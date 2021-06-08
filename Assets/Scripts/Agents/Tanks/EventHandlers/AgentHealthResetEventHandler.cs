using UnityEngine;

/// <summary>
/// Handler to reset the health of the agent when the round starts
/// </summary>


public class AgentHealthResetEventHandler : MonoBehaviour, IObserver<StartRoundEventArgs>
{
    private IResetHealth healthReset;
    
    // TODO: interface
    private GameController gameController;

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