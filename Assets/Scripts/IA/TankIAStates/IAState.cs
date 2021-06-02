using UnityEngine;

public abstract class IAState : IState
{
    #region PROTECTED VARIABLE

    protected TankStateMachine _controller;
    #endregion

    #region CONSTRUCTOR 
    public IAState(TankStateMachine controller)
    {
        _controller = controller;
    }
    #endregion

    #region OWN METHODS
    public virtual void Enter()
    {
        if (_controller.Debug)
        {
            Debug.Log($"Entrou no comportamento {GetType().Name}");
        }
    }

    public virtual void Exit()
    {
        if (_controller.Debug)
        {
            Debug.Log($"Saiu do comportamento {GetType().Name}");
        }
    }

    public virtual void UpdateLogic() 
    {
        if (_controller.Target == null) return;

        Vector2 finalDirection = new Vector2(_controller.Target.position.x, _controller.Target.position.z)
            - new Vector2(_controller.transform.position.x, _controller.transform.position.z).normalized;

        float angle = Vector2.Angle(finalDirection, new Vector2(_controller.transform.forward.x, _controller.transform.forward.z).normalized);

        if(angle <= 10)
        {
            _controller.Fire = true;
        }
        else
        {
            _controller.Fire = false;
        }
    }

    public virtual void UpdatePhysic() { }
    #endregion
}
