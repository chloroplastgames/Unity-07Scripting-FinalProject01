using UnityEngine;

public class HealthBehaviour : Subject<HealthChangedEventArgs>, IDamageable, IResetHealth, ICurrentHealth
{
    public int CurrentHealth => currentHealth;

    [SerializeField] private int maxHealth;

    private int currentHealth;
    private IKillable killer;

    private void Awake()
    {
        ResetHealth();

        killer = GetComponent<IKillable>();
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth == 0) return;

        currentHealth = Mathf.Max(0, currentHealth - damageAmount);

        Notify();

        if (currentHealth == 0)
        {
            killer.Kill();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + healAmount);

        Notify();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;

        Notify();
    }

    public override void Notify()
    {
        IObserver<HealthChangedEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<HealthChangedEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new HealthChangedEventArgs(currentHealth, maxHealth));
        }
    }
}