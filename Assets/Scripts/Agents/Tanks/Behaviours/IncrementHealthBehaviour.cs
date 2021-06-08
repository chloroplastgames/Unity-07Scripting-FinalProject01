using UnityEngine;

public class IncrementHealthBehaviour : Subject<IncrementHealthEventArgs>
{
    private int currentHealth;
    private int maxHealth;

    public int Heal(int currentHealth, int maxHealth, int healAmount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + healAmount);

        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        Notify();

        return currentHealth;
    }

    public int ResetHealth(int maxHealth)
    {
        int currentHealth = maxHealth;

        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        Notify();

        return currentHealth;
    }

    public override void Notify()
    {
        IObserver<IncrementHealthEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<IncrementHealthEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new IncrementHealthEventArgs(currentHealth, maxHealth));
        }
    }
}