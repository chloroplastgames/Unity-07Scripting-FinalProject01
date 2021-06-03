public struct HealthChangedArgs
{
    public readonly int currentHealth;
    public readonly int maxHealth;

    public HealthChangedArgs(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
    }
}