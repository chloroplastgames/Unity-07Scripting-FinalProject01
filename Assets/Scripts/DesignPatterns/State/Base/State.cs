using UnityEngine;

public abstract class State : IState
{
    protected readonly IStateController controller;

    public State(IStateController controller)
    {
        this.controller = controller;
    }

    public abstract void Enter();

    public abstract void Update();

    public abstract void FixedUpdate();

    public abstract void Exit();
}