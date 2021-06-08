using UnityEngine;

/// <summary>
/// Behaviour to decrement agent health and launch DecrementHealthEvent
/// </summary>

public class DecrementHealthBehaviour : Subject<DecrementHealthEventArgs>
{
    private int currentHealth;
    private int maxHealth;

    public int TakeDamage(int currentHealth, int maxHealth, int damageAmount)
    {
        currentHealth = Mathf.Max(0, currentHealth - damageAmount);

        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        Notify();

        return currentHealth;
    }

    public override void Notify()
    {
        IObserver<DecrementHealthEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<DecrementHealthEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new DecrementHealthEventArgs(currentHealth, maxHealth));
        }
    }
}