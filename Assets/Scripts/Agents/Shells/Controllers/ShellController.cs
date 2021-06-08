using UnityEngine;

public class ShellController : MonoBehaviour, IObserver<EndRoundEventArgs>
{
    private IDealDamage damageDealer;
    private IKillable killer;
    private IFaceVelocityDirection velocityDirectionFacer;

    private GameController gameController;

    private void Awake()
    {
        damageDealer = GetComponent<IDealDamage>();
        killer = GetComponent<IKillable>();
        velocityDirectionFacer = GetComponent<IFaceVelocityDirection>();

        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        gameController.EndRoundSubject.Add(this);
    }

    private void OnDestroy()
    {
        gameController.EndRoundSubject?.Remove(this);
    }

    private void LateUpdate()
    {
        velocityDirectionFacer.FaceVelocityDirection();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable target = other.GetComponent<IDamageable>();

        if (target != null)
        {
            damageDealer.DealDamage(target);
        }

        killer.Kill();
    }

    public void OnNotify(EndRoundEventArgs parameter)
    {
        Destroy(gameObject);
    }
}