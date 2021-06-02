using UnityEngine;

public sealed class IAChangeDirection: IAState
{
    #region PRIVATE VARIABLES

    private Vector2 _originalDirection;

    private float _angle;
    #endregion

    #region CONSTRUCTOR
    public IAChangeDirection(TankStateMachine controller) : base(controller)
    {

    }
    #endregion

    #region OWN METHODS
    public override void Enter()
    {
        base.Enter();

        _originalDirection = new Vector2(_controller.transform.forward.x,_controller.transform.forward.z);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        _angle = Vector3.Angle(-_originalDirection, new Vector2(_controller.transform.forward.x,_controller.transform.forward.z));

        if (_angle <= 4)
        {  
            _controller.ChangeBehavior(IABehaviors.MOVE);
        } 
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic(); 

        _controller.Direction = new Vector2(1, 1);
    }
    #endregion
}
