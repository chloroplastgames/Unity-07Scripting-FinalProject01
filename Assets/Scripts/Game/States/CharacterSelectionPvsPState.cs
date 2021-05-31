using UnityEngine;

public class CharacterSelectionPvsPState : State
{
    private readonly CharacterSelectionPvsP canvas;

    private bool player1Ready;
    private bool player2Ready;

    public CharacterSelectionPvsPState(
        IStateController controller,
        CharacterSelectionPvsP canvas
        ) : base(controller)
    {
        this.canvas = canvas;
    }

    public override void Enter()
    {
        base.Enter();

        canvas.gameObject.SetActive(true);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !player1Ready)
        {
            canvas.Player1Text.text = "READY!";
            player1Ready = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !player2Ready)
        {
            canvas.Player2Text.text = "READY!";
            player2Ready = true;
        }

        if (player1Ready && player2Ready)
        {
            controller.SwitchState<CountdownState>();
        }
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
    }
}