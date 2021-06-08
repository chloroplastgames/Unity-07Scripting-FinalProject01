using UnityEngine;

public class DealDamageBehaviour : MonoBehaviour, IDealDamage
{
    // Change from outside with shot power up
    public int Damage { get => damage; set => damage = value; }

    [SerializeField] private int damage = 1;

    public void DealDamage(IDamageable target)
    {
        target.TakeDamage(damage);
    }
}