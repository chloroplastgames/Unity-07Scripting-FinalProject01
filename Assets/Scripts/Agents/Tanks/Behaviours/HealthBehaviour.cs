using UnityEngine;

public class HealthBehaviour : Subject<HealthArgs>, IDamageable, IResetHealth, ICurrentHealth
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
        currentHealth = Mathf.Max(0, currentHealth - damageAmount);

        print($"{gameObject} took {damageAmount} damage! {currentHealth} health left");

        Notify();

        if (currentHealth == 0)
        {
            killer.Kill();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public override void Notify()
    {
        IObserver<HealthArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<HealthArgs> observer in observersPhoto)
        {
            observer.OnNotify(new HealthArgs(currentHealth, maxHealth));
        }
    }
}