using UnityEngine;

/// <summary>
/// Behaviour of the speed powerup. Increments translation for a time, don't stack and don't reset duration
/// </summary>

public class SpeedPowerUpBehaviour : MonoBehaviour, IPowerUp, IObserver<EndRoundEventArgs>
{
    public string PowerUpName => powerUpName;

    [SerializeField] private string powerUpName = "speed";
    [SerializeField] private float speedMult = 1.5f;
    [SerializeField] private float time = 10f;

    private TranslateBehaviour translateBehaviour;
    private GameController gameController;

    private float originalSpeed;
    private Coroutine speedRoutine;

    private void Awake()
    {
        translateBehaviour = GetComponent<TranslateBehaviour>();

        gameController = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        gameController.EndRoundSubject.Add(this);

        originalSpeed = translateBehaviour.Speed;
    }

    private void OnDisable()
    {
        gameController.EndRoundSubject.Remove(this);
    }

    // Has acess to agent translation speed
    public void Consume()
    {
        if (speedRoutine != null) return;

        translateBehaviour.Speed *= speedMult;

        speedRoutine = CoroutinesHelperSingleton.Instance.WaitForSeconds(time, () => ResetSpeed());
    }

    public void OnNotify(EndRoundEventArgs parameter)
    {
        if (speedRoutine != null)
        {
            CoroutinesHelperSingleton.Instance.StopCoroutine(speedRoutine);
        }

        ResetSpeed();
    }

    private void ResetSpeed()
    {
        translateBehaviour.Speed = originalSpeed;

        speedRoutine = null;
    }
}