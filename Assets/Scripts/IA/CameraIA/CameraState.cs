using UnityEngine;

public abstract class CameraState : IState
{
    #region PROTECTED VARIABLES

    protected CameraStateMachine _controller;

    protected Quaternion Angle;

    protected float Distance;
    #endregion

    #region CONSTRUCTOR
    public CameraState(CameraStateMachine controller)
    {
        _controller = controller;
        Angle = Quaternion.Euler(30, _controller.transform.rotation.eulerAngles.y, _controller.transform.rotation.eulerAngles.z);
        Distance = 10;
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
         
    }

    public virtual void UpdatePhysic()
    { 

        Vector3 lookDirection = Quaternion.Euler(30, _controller.transform.rotation.eulerAngles.y,0) * Vector3.forward;

        Vector3 lookPosition = _controller.transform.position - lookDirection * Distance;

        _controller.MainCamera.transform.SetPositionAndRotation(lookPosition, Quaternion.Euler(30, _controller.transform.rotation.eulerAngles.y,0));
    }
    #endregion
}
