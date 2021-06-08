using UnityEngine;

public class DealDamageBehaviour : MonoBehaviour, IDealDamage
{
    public int Damage { get => minDamage; set => minDamage = value; }

    [SerializeField] private int minDamage = 1;

    public void DealDamage(IDamageable target)
    {
        target.TakeDamage(minDamage);
    }
}