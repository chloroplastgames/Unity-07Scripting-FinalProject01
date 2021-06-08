using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable, IResetHealth, ICurrentHealth
{
    public int CurrentHealth => currentHealth;

    [SerializeField] private int maxHealth;

    private int currentHealth;

    private IKillable killer;
    private DecrementHealthBehaviour decrementHealthBehaviour;
    private IncrementHealthBehaviour incrementHealthBehaviour;

    private void Awake()
    {
        killer = GetComponent<IKillable>();
        decrementHealthBehaviour = GetComponent<DecrementHealthBehaviour>();
        incrementHealthBehaviour = GetComponent<IncrementHealthBehaviour>();
    }

    private void Start()
    {
        ResetHealth();
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth == 0) return;

        currentHealth = decrementHealthBehaviour.TakeDamage(currentHealth, maxHealth, damageAmount);

        if (currentHealth == 0)
        {
            killer.Kill();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth = incrementHealthBehaviour.Heal(currentHealth, maxHealth, healAmount);
    }

    public void ResetHealth()
    {
        currentHealth = incrementHealthBehaviour.ResetHealth(maxHealth);
    }
}