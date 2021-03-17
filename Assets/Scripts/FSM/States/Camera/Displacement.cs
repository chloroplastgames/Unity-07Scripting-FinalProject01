using System.Collections; 
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/States/Camera/Displavement")] 
public class Displacement : AbstractState<CameraController>
{
    private Vector3 _center;  

    private float _time;

    [SerializeField] private float _distanceCenter;

    public override IEnumerator Enter()
    {
        var IEnumeratorBase = base.Enter();
        while (true)
        {
            yield return IEnumeratorBase.Current;
            if (IEnumeratorBase.MoveNext() == false) break;
        }

        _center = GameManager.Instance.GetPlayerTransform().position + GameManager.Instance.GetEnemyTransform().position;

        _center = _center / 2;

        _center.y = _controller.GetCameraTransform().position.y;

        _center.z -= _distanceCenter;

        yield break;
    }
    public override void StateUpdate()
    { 

        float distance = Vector3.Distance(_controller.GetCameraTransform().position, _center); 

        if (distance > 0.01f)
        {
            _time += Time.deltaTime / _controller.GetData().Time; 

            Vector3 newPos = Vector3.Lerp(_controller.GetCameraTransform().position, _center, _time);

            _controller.GetCameraTransform().position = newPos;
        }
        else
        {
            _controller.ChangeState(_controller.GetBehavious(CameraBehavior.WAITING));
            _time = 0;
        }
    }
}
