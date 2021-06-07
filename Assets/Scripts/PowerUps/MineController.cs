using UnityEngine;

public class MineController : MonoBehaviour, IObserver<EndRoundEventArgs>
{
    [SerializeField] private float timeToArm = 3;

    private IDealDamage damageDealer;
    private IKillable killer;

    private GameController gameController;

    private bool armed = false;
    private Coroutine armRoutine;

    private void Awake()
    {
        damageDealer = GetComponent<IDealDamage>();
        killer = GetComponent<IKillable>();

        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        gameController.EndRoundSubject.Add(this);

        armRoutine = CoroutinesHelperSingleton.Instance.WaitForSeconds(timeToArm, () => ArmMine());
    }

    private void OnDestroy()
    {
        gameController.EndRoundSubject?.Remove(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!armed) return;

        IDamageable target = other.GetComponent<IDamageable>();

        if (target != null)
        {
            damageDealer.DealDamage(target);
        }

        killer.Kill();
    }

    public void OnNotify(EndRoundEventArgs parameter)
    {
        CoroutinesHelperSingleton.Instance.StopCoroutine(armRoutine);

        Destroy(gameObject);
    }

    private void ArmMine()
    {
        armed = true;
    }
}