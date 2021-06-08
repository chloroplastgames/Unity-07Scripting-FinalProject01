using UnityEngine;

public class ShellController : MonoBehaviour, IObserver<EndRoundEventArgs>
{
    private IDealDamage damageDealer;
    private IKillable killer;
    private IFaceVelocityDirection velocityDirectionFacer;

    // TODO: interface
    private GameController gameController;

    private void Awake()
    {
        damageDealer = GetComponent<IDealDamage>();
        killer = GetComponent<IKillable>();
        velocityDirectionFacer = GetComponent<IFaceVelocityDirection>();

        gameController = FindObjectOfType<GameController>();
    }

    // It's accessing a property, throws NullReferenceException on Awake
    private void Start()
    {
        gameController.EndRoundSubject.Add(this);
    }

    // Remove only it has been added
    private void OnDestroy()
    {
        gameController.EndRoundSubject?.Remove(this);
    }

    // Rendering in LateUpdate
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
        // Can't use killer because it will spawn an explosion
        Destroy(gameObject);
    }
}