public struct HealthChangedEventArgs
{
    public readonly int currentHealth;
    public readonly int maxHealth;

    public HealthChangedEventArgs(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
    }
}