using UnityEngine;

public class ShellController : MonoBehaviour, IObserver<TimerArgs>, IObserver<DieArgs>
{
    private IKillable killer;
    private IDealDamage damageDealer;
    private IFaceVelocityDirection velocityDirectionFacer;

    // TODO: Subscribe to events
    private ICountdownEvents countdownEvents;
    // TODO: Setup dieSubjects

    private void Awake()
    {
        killer = GetComponent<IKillable>();
        damageDealer = GetComponent<IDealDamage>();
        velocityDirectionFacer = GetComponent<IFaceVelocityDirection>();
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

    public void OnNotify(TimerArgs parameter)
    {
        killer.Kill();
    }

    public void OnNotify(DieArgs parameter)
    {
        killer.Kill();
    }
}