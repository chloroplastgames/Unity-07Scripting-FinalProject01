using UnityEngine;
using UnityEngine.UI;

public class LeftHealthHUDBehaviour : MonoBehaviour, IObserver<HealthChangedArgs>, ISetupHealthHUD
{
    [SerializeField] private Slider healthSlider;

    private ISubject<HealthChangedArgs> healthSubject;

    private void OnDisable()
    {
        healthSubject.Remove(this);
    }

    public void Setup(ISubject<HealthChangedArgs> healthSubject)
    {
        this.healthSubject = healthSubject;

        this.healthSubject.Add(this);
    }

    public void OnNotify(HealthChangedArgs healthChangedArgs)
    {
        UpdateHealthSlider(healthChangedArgs.currentHealth, healthChangedArgs.maxHealth);
    }

    private void UpdateHealthSlider(int currentHealth, int maxHealth)
    {
        healthSlider.value = (float)currentHealth / maxHealth;
    }
}