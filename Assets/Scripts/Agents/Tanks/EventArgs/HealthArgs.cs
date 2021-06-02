public struct HealthArgs
{
    public readonly int currentHealth;
    public readonly int maxHealth;

    public HealthArgs(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
    }
}