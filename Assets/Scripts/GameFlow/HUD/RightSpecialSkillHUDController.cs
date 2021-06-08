using UnityEngine;
using UnityEngine.UI;

// Controller and behaviour
public class RightSpecialSkillHUDController : MonoBehaviour, IObserver<SetupGameEventArgs>, IObserver<PowerUpEventArgs>
{
    [SerializeField] private Text specialSkillText;

    private GameController gameController;

    private ISubject<PowerUpEventArgs> powerUpSubject;

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
        powerUpSubject?.Remove(this);
        gameController.SetupGameSubject?.Remove(this);
    }

    public void OnNotify(SetupGameEventArgs setupGameEventArgs)
    {
        powerUpSubject = setupGameEventArgs.agent2Instance.GetComponent<ISubject<PowerUpEventArgs>>();

        if (powerUpSubject != null)
        {
            powerUpSubject.Add(this);
        }
    }

    public void OnNotify(PowerUpEventArgs powerUpEventArgs)
    {
        specialSkillText.text = powerUpEventArgs.name.ToUpper();
    }
}