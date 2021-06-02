using UnityEngine;

public class CameraZoomState : CameraState
{
    #region PRIVATE VARIABLES

    private float _timeElpased;

    private float _originalDistance;

    private float _totalTime = 5;
    #endregion

    #region CONSTRUCTOR
    public CameraZoomState(CameraStateMachine controller) : base(controller)
    {

    }
    #endregion

    #region OWN METHODS
    public override void Enter()
    {
        base.Enter();
        _originalDistance = Distance;
    }

    public override void Exit()
    {
        base.Exit();
        _timeElpased = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _timeElpased += Time.deltaTime;

        if (Distance > 5 && Mathf.Pow(_totalTime, _timeElpased)/_totalTime < (_totalTime / 2))
        {
            Distance = Mathf.Lerp(_originalDistance, 5, Mathf.Pow(_totalTime, _timeElpased) / _totalTime / (_totalTime/2));
        }else if(Distance < _originalDistance)
        {
            Distance = Mathf.Lerp(5, _originalDistance, (Mathf.Pow(_totalTime, _timeElpased) / _totalTime - (_totalTime / 2)));
        } 
        if(Mathf.Pow(_totalTime, _timeElpased) / _totalTime > _totalTime)
        {
            _controller.ChangeBehavior(CameraBehavior.NORMAL);
        }
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic();
    }
    #endregion
}