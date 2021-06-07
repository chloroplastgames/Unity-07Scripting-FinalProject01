using UnityEngine;

public class ShotPowerUpBehaviour : MonoBehaviour, IPowerUp, IObserver<EndRoundEventArgs>
{
    public string PowerUpName => powerUpName;

    [SerializeField] private string powerUpName = "shot";
    [SerializeField] private float multiplier = 1.5f;
    [SerializeField] private float time = 10f;

    private HoldShootController holdShootController;
    private GameController gameController;

    float originalMultiplier;
    private Coroutine shotRoutine;

    private void Awake()
    {
        holdShootController = GetComponent<HoldShootController>();

        gameController = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        gameController.EndRoundSubject.Add(this);

        originalMultiplier = holdShootController.Multiplier;
    }

    private void OnDisable()
    {
        gameController.EndRoundSubject.Remove(this);
    }

    public void Consume()
    {
        if (shotRoutine != null) return;

        holdShootController.Multiplier = multiplier;

        CoroutinesHelperSingleton.Instance.WaitForSeconds(time, () => ResetMultiplier());
    }

    public void OnNotify(EndRoundEventArgs parameter)
    {
        if (shotRoutine != null)
        {
            CoroutinesHelperSingleton.Instance.StopCoroutine(shotRoutine);
        }
        
        ResetMultiplier();
    }

    private void ResetMultiplier()
    {
        holdShootController.Multiplier = originalMultiplier;

        shotRoutine = null;
    }
}