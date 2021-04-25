using UnityEngine;

public class HealthBehaviour : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth;

    private int currentHealth;

    private IKillable killer;

    private void Awake()
    {
        currentHealth = maxHealth;

        killer = GetComponent<IKillable>();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth = Mathf.Max(0, currentHealth - damageAmount);

        print($"{gameObject} took {damageAmount} damage! {currentHealth} health left");

        if (currentHealth == 0)
        {
            killer.Kill();

            Destroy(this); // TODO
        }
    }
}