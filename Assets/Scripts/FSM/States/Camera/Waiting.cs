using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/States/Camera/Waiting")]

public class Waiting : AbstractState<CameraController>
{
    public override void StateUpdate()
    {
        float distance = Vector3.Distance(GameManager.Instance.GetPlayerTransform().position, GameManager.Instance.GetEnemyTransform().position);

        if(distance > _controller.GetData().MaxDistanceCenter)
        {
            _controller.ChangeState(_controller.GetBehavious(CameraBehavior.DISPLACEMENT));
        }
    }
}
