using UnityEngine;

public class CountdownState : State
{
    private readonly Countdown canvas;
    private readonly GameObject cameraGameplay;
    private readonly GameObject cameraMainMenu;

    public CountdownState(
        IStateController controller,
        Countdown canvas,
        GameObject cameraGameplay,
        GameObject cameraMainMenu
        ) : base(controller)
    {
        this.canvas = canvas;
        this.cameraGameplay = cameraGameplay;
        this.cameraMainMenu = cameraMainMenu;
    }

    public override void Enter()
    {
        base.Enter();

        cameraMainMenu.SetActive(false);
        cameraGameplay.SetActive(true);
        canvas.gameObject.SetActive(true);

        RoutineHelperSingleton.Instance.WaitForSeconds(1f, () => ChangeCountdownText(2));
        RoutineHelperSingleton.Instance.WaitForSeconds(2f, () => ChangeCountdownText(1));
        RoutineHelperSingleton.Instance.WaitForSeconds(3f, () => SwitchToRoundState());
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

        canvas.gameObject.SetActive(false);

        // Reset
        canvas.CountdownText.text = 3.ToString();
    }

    private void ChangeCountdownText(int number)
    {
        canvas.CountdownText.text = number.ToString();
    }

    private void SwitchToRoundState()
    {
        controller.SwitchState<RoundState>();
    }
}