using UnityEngine;

public class ShellController : MonoBehaviour
{
    private IKillable killer;
    private IDealDamage damageDealer;

    private void Awake()
    {
        killer = GetComponent<IKillable>();
        damageDealer = GetComponent<IDealDamage>();
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
}