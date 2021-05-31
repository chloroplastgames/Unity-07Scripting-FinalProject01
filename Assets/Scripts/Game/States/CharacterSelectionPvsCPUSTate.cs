using UnityEngine;

public class CharacterSelectionPvsCPUSTate : State
{
    private readonly CharacterSelectionPvsCPU canvas;

    public CharacterSelectionPvsCPUSTate(
        IStateController controller,
        CharacterSelectionPvsCPU canvas
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
        if (Input.GetKeyDown(KeyCode.B))
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