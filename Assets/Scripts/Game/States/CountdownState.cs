using UnityEngine;

public class CountdownState : State
{
    private readonly CanvasCountdown countdown;
    private readonly GameObject cameraGameplay;
    private readonly GameObject cameraMainMenu;

    private const int CountdownTime = 3;

    private int time;

    public CountdownState(
        IStateController controller,
        CanvasCountdown countdown,
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
        base.Enter();

        cameraMainMenu.SetActive(false);
        cameraGameplay.SetActive(true);
        countdown.gameObject.SetActive(true);

        // Gameplay camera must be active
        GameManagerSingleton.Instance.SetupRound();

        time = CountdownTime;

        ChangeCountdownText(time);
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
        base.Exit();

        countdown.gameObject.SetActive(false);
    }

    private void ChangeCountdownText(int time)
    {
        if (time == 0)
        {
            SwitchToRoundState();
            return;
        }

        countdown.CountdownText.text = time.ToString();
        time--;

        CoroutinesHelperSingleton.Instance.WaitForSeconds(1f, () => ChangeCountdownText(time));
    }

    private void SwitchToRoundState()
    {
        controller.SwitchState<RoundState>();
    }
}