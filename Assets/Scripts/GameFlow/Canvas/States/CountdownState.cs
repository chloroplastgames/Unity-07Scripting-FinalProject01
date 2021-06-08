using UnityEngine;

public class CountdownState : State, IObserver<CountdownEventArgs>
{
    private readonly ICountdown countdown;
    private readonly GameObject cameraGameplay;
    private readonly GameObject cameraMainMenu;

    public CountdownState(
        IStateController controller,
        ICountdown countdown,
        GameObject cameraGameplay,
        GameObject cameraMainMenu
        ) : base(controller)
    {
        this.countdown = countdown;
        this.cameraGameplay = cameraGameplay;
        this.cameraMainMenu = cameraMainMenu;
    }

    public override void Enter()
    {
        countdown.CounterSubject.Add(this);

        cameraGameplay.SetActive(true);
        cameraMainMenu.SetActive(false);
        countdown.CanvasCountdown.SetActive(true);

        countdown.StartCountdown();
    }

    public override void Update()
    {
        return;
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        countdown.CounterSubject.Remove(this);

        countdown.CanvasCountdown.SetActive(false);
    }

    public void OnNotify(CountdownEventArgs parameter)
    {
        SwitchToHUDState();
    }

    private void SwitchToHUDState()
    {
        controller.SwitchState<HUDState>();
    }
}