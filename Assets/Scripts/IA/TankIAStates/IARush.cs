using UnityEngine;

public sealed class IARush : IAState
{
    #region PRIVATE VARIABLE

    private float _distance;
    #endregion

    #region CONSTRUCTOR
    public IARush(TankStateMachine controller) : base(controller)
    {
         
    }
    #endregion

    #region OWN METHODS

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        _distance = Vector3.Distance(_controller.transform.position, _controller.Target.position);

        if(_distance >= 20)
        {
            _controller.Target = null;

            _controller.ChangeBehavior(IABehaviors.MOVE);
        }else if(_distance < 10)
        {
            _controller.ChangeBehavior(IABehaviors.STOP);
        }
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic();

        Vector2 finalDirection = new Vector2(_controller.Target.position.x, _controller.Target.position.z)
            - new Vector2(_controller.transform.position.x,_controller.transform.position.z);

        float angle = Vector2.Angle(finalDirection, new Vector2(_controller.transform.forward.x, _controller.transform.forward.z));

        _controller.Direction = new Vector2((angle>5)?1:0,1);
    }
    #endregion
}
