using UnityEngine;

public class ShockwaveBehaviour : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private bool hasDamaged;

    private void OnEnable()
    {
        hasDamaged = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // In order to avoid multiple stacks of damage
        if (hasDamaged) return;

        IDamageable target = other.GetComponent<IDamageable>();

        if (target != null)
        {
            target.TakeDamage(damage);

            hasDamaged = true;
        }
    }
}