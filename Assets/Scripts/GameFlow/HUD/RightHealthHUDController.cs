using UnityEngine;
using UnityEngine.UI;

public class RightHealthHUDController : MonoBehaviour, IObserver<SetupGameEventArgs>, IObserver<HealthChangedEventArgs>
{
    [SerializeField] private Slider healthSlider;

    private ISubject<HealthChangedEventArgs> healthSubject;

    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        gameController.SetupGameSubject.Add(this);
    }

    private void OnDestroy()
    {
        healthSubject?.Remove(this);
        gameController.SetupGameSubject?.Remove(this);
    }

    public void OnNotify(SetupGameEventArgs setupGameArgs)
    {
        ISubject<HealthChangedEventArgs> healthSubject = setupGameArgs.agent2Instance.GetComponent<ISubject<HealthChangedEventArgs>>();

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