using UnityEngine;
using UnityEngine.UI;

public abstract class HealthHUDBehaviourBase : MonoBehaviour, IObserver<HealthArgs>
{
    [SerializeField] private Slider healthSlider;

    protected ISubject<HealthArgs> healthSubject;

    protected abstract void Awake();

    private void OnEnable()
    {
        healthSubject.Add(this);

        UpdateHealthSlider(new HealthArgs((int)healthSlider.maxValue, (int)healthSlider.maxValue));
    }

    private void OnDisable()
    {
        healthSubject.Remove(this);
    }

    public void OnNotify(HealthArgs parameter)
    {
        UpdateHealthSlider(parameter);
    }

    private void UpdateHealthSlider(HealthArgs paramenter)
    {
        healthSlider.value = (float)paramenter.currentHealth / paramenter.maxHealth;
    }
}