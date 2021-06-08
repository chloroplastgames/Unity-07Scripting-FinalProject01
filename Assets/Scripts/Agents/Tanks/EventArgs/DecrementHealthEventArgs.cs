public struct DecrementHealthEventArgs
{
    public readonly int currentHealth;
    public readonly int maxHealth;

    public DecrementHealthEventArgs(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
    }
}