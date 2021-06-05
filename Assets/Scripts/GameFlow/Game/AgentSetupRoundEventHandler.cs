using UnityEngine;

public class AgentSetupRoundEventHandler : MonoBehaviour, IObserver<StartRoundEventArgs>
{
    private ISubject<StartRoundEventArgs> setupRoundSubject;
    private IResetHealth healthReset;
    private Transform initialPoint;

    private void Awake()
    {
        setupRoundSubject = FindObjectOfType<StartRoundBehaviour>();

        healthReset = GetComponent<IResetHealth>();
    }

    private void OnEnable()
    {
        setupRoundSubject.Add(this);
    }

    private void OnDisable()
    {
        setupRoundSubject.Remove(this);
    }

    public void OnNotify(StartRoundEventArgs parameter)
    {
        healthReset.ResetHealth();

        gameObject.transform.position = initialPoint.position;
        gameObject.transform.rotation = initialPoint.rotation;
    }
}