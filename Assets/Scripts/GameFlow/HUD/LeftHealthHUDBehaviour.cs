using UnityEngine;
using UnityEngine.UI;

public class LeftHealthHUDBehaviour : MonoBehaviour, IObserver<HealthChangedEventArgs>, IObserver<SetupGameEventArgs>
{
    [SerializeField] private Slider healthSlider;

    private ISubject<HealthChangedEventArgs> healthSubject;

    private void OnDisable()
    {
        healthSubject.Remove(this);
    }

    public void OnNotify(SetupGameEventArgs setupGameArgs)
    {
        ISubject<HealthChangedEventArgs> healthSubject = setupGameArgs.agent1Instance.GetComponent<ISubject<HealthChangedEventArgs>>();

        Setup(healthSubject);
    }

    public void OnNotify(HealthChangedEventArgs healthChangedArgs)
    {
        UpdateHealthSlider(healthChangedArgs.currentHealth, healthChangedArgs.maxHealth);
    }

    private void Setup(ISubject<HealthChangedEventArgs> healthSubject)
    {
        this.healthSubject = healthSubject;

        this.healthSubject.Add(this);
    }

    private void UpdateHealthSlider(int currentHealth, int maxHealth)
    {
        healthSlider.value = (float)currentHealth / maxHealth;
    }
}