using System.Collections; 
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/States/Camera/Shaking")]
public class Shaking : AbstractState<CameraController>
{ 

    private Vector3 _posOriginal;

    private float _timeElapsed;

    [SerializeField] private float _time;

    [SerializeField] private float _magnitude; 

    public override IEnumerator Enter()
    {
        var IEnumeratorBase = base.Enter();

        while (true)
        {
            yield return IEnumeratorBase.Current;

            if (IEnumeratorBase.MoveNext() == false) break;
        }

        _posOriginal = _controller.GetCameraTransform().position;

        yield break;
    }
    public override void StateUpdate()
    {  
        if(_timeElapsed <= _time)
        {
            _timeElapsed += Time.deltaTime; 

            Vector2 shaking = new Vector2((float)Random.Range(-1, 1), (float)Random.Range(-1, 1)) * _magnitude;

            _controller.GetCameraTransform().position = _posOriginal + new Vector3(shaking.x, 0, shaking.y);
        }
        else
        { 
            _controller.ChangeState(_controller.GetBehavious(CameraBehavior.WAITING));

            _timeElapsed = 0;
        } 

    }
    public override IEnumerator Exit()
    {  
        var IEnumeratorBase = base.Exit();

        while (true)
        {
            yield return IEnumeratorBase.Current;

            if (IEnumeratorBase.MoveNext() == false) break;
        } 

        _controller.GetCameraTransform().position = _posOriginal;

        yield break;
    }
}
