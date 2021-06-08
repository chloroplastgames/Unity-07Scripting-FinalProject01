public struct IncrementHealthEventArgs
{
    public readonly int currentHealth;
    public readonly int maxHealth;

    public IncrementHealthEventArgs(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
    }
}