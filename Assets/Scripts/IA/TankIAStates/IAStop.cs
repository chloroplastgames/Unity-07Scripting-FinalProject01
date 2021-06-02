using UnityEngine;

public sealed class IAStop: IAState
{
    #region PRIVATE VARIABLE
    private float _distance;
    #endregion

    #region CONSTRUCTOR
    public IAStop(TankStateMachine controller) : base(controller)
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

        if (_distance >= 10)
        {  
            _controller.ChangeBehavior(IABehaviors.MOVE);
        } 
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic(); 

        _controller.Direction = new Vector2( 0, 0);
    }
    #endregion
}
