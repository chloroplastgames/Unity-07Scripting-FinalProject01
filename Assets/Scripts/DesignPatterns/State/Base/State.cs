using UnityEngine;

public abstract class State : IState
{
    protected readonly IStateController controller;

    public State(IStateController controller)
    {
        this.controller = controller;
    }

    public virtual void Enter()
    {
        Debug.Log($"Enter {GetType()}");
    }

    public abstract void Update();

    public abstract void FixedUpdate();

    public virtual void Exit()
    {
        Debug.Log($"Exit {GetType()}");
    }
}