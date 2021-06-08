using UnityEngine;
using UnityEngine.UI;

// Controller and behaviour
public class RightHealthHUDController : MonoBehaviour, IObserver<SetupGameEventArgs>,
    IObserver<DecrementHealthEventArgs>, IObserver<IncrementHealthEventArgs>
{
    [SerializeField] private Slider healthSlider;

    private GameController gameController;

    private ISubject<DecrementHealthEventArgs> damageSubject;
    private ISubject<IncrementHealthEventArgs> healSubject;

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
        damageSubject?.Remove(this);
        healSubject?.Remove(this);
        gameController.SetupGameSubject?.Remove(this);
    }

    public void OnNotify(SetupGameEventArgs setupGameArgs)
    {
        ISubject<DecrementHealthEventArgs> damageSubject = setupGameArgs.agent2Instance.GetComponent<ISubject<DecrementHealthEventArgs>>();
        ISubject<IncrementHealthEventArgs> healSubject = setupGameArgs.agent2Instance.GetComponent<ISubject<IncrementHealthEventArgs>>();

        Setup(damageSubject, healSubject);
    }

    public void OnNotify(DecrementHealthEventArgs decrementHealthEventArgs)
    {
        UpdateHealthSlider(decrementHealthEventArgs.currentHealth, decrementHealthEventArgs.maxHealth);
    }

    public void OnNotify(IncrementHealthEventArgs incrementHealthEventArgs)
    {
        UpdateHealthSlider(incrementHealthEventArgs.currentHealth, incrementHealthEventArgs.maxHealth);
    }

    private void Setup(ISubject<DecrementHealthEventArgs> damageSubject, ISubject<IncrementHealthEventArgs> healSubject)
    {
        this.damageSubject = damageSubject;
        this.damageSubject.Add(this);

        this.healSubject = healSubject;
        this.healSubject.Add(this);
    }

    private void UpdateHealthSlider(int currentHealth, int maxHealth)
    {
        healthSlider.value = (float)currentHealth / maxHealth;
    }
}