using UnityEngine;

public class CameraIAState: IState
{
    protected CameraStateMachine Controller;

    private float _distance = 3;
    public CameraIAState(CameraStateMachine cameraStateMachine)
    {
        Controller = cameraStateMachine; 
    }
    public virtual void Enter()
    {
        if (Controller.Debug)
        {
            Debug.Log($"Entrou no comportamento {GetType().Name}");
        }
    }

    public void Exit()
    {
        if (Controller.Debug)
        {
            Debug.Log($"Saiu do comportamento {GetType().Name}");
        }
    }

    public virtual void UpdateLogic()
    {
        Quaternion lookRotation = Quaternion.Euler(20,Controller.transform.rotation.eulerAngles.y,Controller.transform.rotation.eulerAngles.z);

        Vector3 lookDirection = lookRotation * (Vector3.forward * 3) - Vector3.up;

        Vector3 lookPosition = Controller.transform.position - lookDirection * _distance;

        Controller.MainCamera.transform.SetPositionAndRotation(lookPosition, lookRotation);
    }

    public virtual void UpdatePhysic()
    {

    }
}