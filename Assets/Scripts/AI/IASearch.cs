using UnityEngine;

public class IASearch : TankBehaviorState
{
    public IASearch(TankStateMachine tankStateMachine) : base(tankStateMachine) { }

    public override void Enter()
    {
        base.Enter(); 

        Controller.FinalPos = FieldController.Instance.GetRandomPosition();

        new GameObject().transform.position = new Vector3(Controller.FinalPos.x, 0, Controller.FinalPos.y);
    }

    public override void UpdateLogic()
    {
        Controller.ChangeBehavior(BehaviorTank.MOVE);
    }
}