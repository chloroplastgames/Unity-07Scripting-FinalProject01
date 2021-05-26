using UnityEngine;

public class DealDamageBehaviour : MonoBehaviour, IDealDamage
{
    [SerializeField] private int damage;

    public void DealDamage(IDamageable target)
    {
        target.TakeDamage(damage);
    }
}