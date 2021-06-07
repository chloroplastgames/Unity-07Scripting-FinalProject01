public class AgentPowerUpController : Subject<PowerUpEventArgs>, IPowerUpable, IConsumePowerUp, IObserver<EndRoundEventArgs>
{
    private IPowerUp repairPowerUp;
    private IPowerUp speedPowerUp;
    private IPowerUp shotPowerUp;
    private IPowerUp minePowerUp;
    private IPowerUp shockwavePowerUp;

    private IPowerUp powerUp;

    private GameController gameController;

    private void Awake()
    {
        repairPowerUp = GetComponent<RepairPowerUpBehaviour>();
        speedPowerUp = GetComponent<SpeedPowerUpBehaviour>();
        shotPowerUp = GetComponent<ShotPowerUpBehaviour>();
        minePowerUp = GetComponent<MinePowerUpBehaviour>();
        shockwavePowerUp = GetComponent<ShockwavePowerUpBehaviour>();

        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        gameController.EndRoundSubject.Add(this);
    }

    private void OnDestroy()
    {
        gameController.EndRoundSubject?.Remove(this);
    }

    public void ApplyPowerUp(int id)
    {
        if (powerUp != null) return;

        switch (id)
        {
            case 1: // Repair
                powerUp = repairPowerUp;
                ConsumePowerUp();
                break;
            case 2: // Speed
                powerUp = speedPowerUp;
                ConsumePowerUp();
                break;
            case 3: // Shot
                powerUp = shotPowerUp;
                ConsumePowerUp();
                break;
            case 4: // Mine
                powerUp = minePowerUp;
                Notify();
                break;
            case 5: // Shockwave
                powerUp = shockwavePowerUp;
                Notify();
                break;
        }
    }

    public void ConsumePowerUp()
    {
        if (powerUp == null) return;

        powerUp.Consume();

        powerUp = null;

        Notify();
    }

    public void OnNotify(EndRoundEventArgs parameter)
    {
        powerUp = null;

        Notify();
    }

    public override void Notify()
    {
        IObserver<PowerUpEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<PowerUpEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new PowerUpEventArgs(powerUp != null ? powerUp.PowerUpName : "none"));
        }
    }
}