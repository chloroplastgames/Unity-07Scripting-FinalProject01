using UnityEngine;

public class CameraMoveState : CameraState
{
    #region CONSTRUCTOR
    public CameraMoveState(CameraStateMachine controller) : base(controller)
    {

    }
    #endregion

    #region OWN METHODS
    public override void Enter()
    {
        base.Enter();
        _controller.MainCamera.transform.rotation = Quaternion.Euler(30, 0, 0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic();
    }
    #endregion
}

