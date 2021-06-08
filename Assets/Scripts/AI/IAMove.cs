using UnityEngine;

internal class IAMove : TankBehaviorState
{
    private float _angle; 
    public IAMove(TankStateMachine tankStateMachine) : base(tankStateMachine)
    {
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        _angle = Vector2.Angle((Controller.FinalPos - new Vector2(Controller.transform.position.x, Controller.transform.position.z)).normalized, Controller.transform.forward);

        float distance = Vector2.Distance(Controller.FinalPos, new Vector2(Controller.transform.position.x, Controller.transform.position.z));

         

        if (distance < 10)
        {
            Controller.ChangeBehavior(BehaviorTank.SEARCH);
        } 

        if (_angle > 80)
        {
            Controller.Direction = new Vector2(1, 0.5f);
        }
        else if(_angle > 40)
        {
            Controller.Direction = new Vector2(0.8f, 0.8f);
        }
        else if(_angle > 20)
        {
            Controller.Direction = new Vector2(0.1f, 1);
        }
        else
        {
            Controller.Direction = new Vector2(0, 1);
        } 
    }
    public override void UpdatePhysic()
    {
        base.UpdatePhysic(); 
    }
}