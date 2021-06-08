using UnityEngine;

/// <summary>
/// Controller to control agent health. Should have access to DecrementHealthEvent and IncrementHealthEvent
/// </summary>

public class HealthController : MonoBehaviour, IDamageable, IResetHealth, ICurrentHealth
{
    // TODO: give access to events and pass events with the controller

    public int CurrentHealth => currentHealth;

    // TODO: move to config ScriptableObject
    [SerializeField] private int maxHealth;

    private int currentHealth;

    private IKillable killer;

    // TODO: interfaces
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