public interface IDealDamage
{
    int Damage { set; }
    void DealDamage(IDamageable target);
}