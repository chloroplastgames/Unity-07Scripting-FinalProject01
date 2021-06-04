using UnityEngine;
using UnityEngine.UI;

public abstract class HealthHUDBehaviourBase : MonoBehaviour, IObserver<HealthChangedArgs>
{
    [SerializeField] private Slider healthSlider;

    protected ISubject<HealthChangedArgs> healthSubject;

    protected abstract void Awake();

    private void OnEnable()
    {
        healthSubject.Add(this);

        healthSlider.value = healthSlider.maxValue; // TODO: Update from the agent
    }

    private void OnDisable()
    {
        healthSubject.Remove(this);
    }

    public void OnNotify(HealthChangedArgs healthChangedArgs)
    {
        UpdateHealthSlider(healthChangedArgs);
    }

    private void UpdateHealthSlider(HealthChangedArgs healthChangedArgs)
    {
        healthSlider.value = (float)healthChangedArgs.currentHealth / healthChangedArgs.maxHealth;
    }
}