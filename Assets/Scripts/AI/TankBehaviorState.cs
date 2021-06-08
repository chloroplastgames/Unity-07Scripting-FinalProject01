using UnityEngine;

public abstract class TankBehaviorState : IState
{
    protected TankStateMachine Controller;

    private WeaponsController _weaponController;
    public TankBehaviorState(TankStateMachine tankStateMachine)
    {
        Controller = tankStateMachine;
        _weaponController = tankStateMachine.GetComponent<WeaponsController>();
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
        if(_weaponController.Target != null && _weaponController.Target.GetTransform().gameObject.activeSelf)
        {
            Controller.PrimaryFire = true;
        }
        else
        {
            Controller.PrimaryFire = false;
        }
        if(_weaponController.Target != null)
        {

            float distance = Vector2.Distance(new Vector2(Controller.transform.position.x, Controller.transform.position.z),
                new Vector2(_weaponController.Target.GetTransform().position.x, _weaponController.Target.GetTransform().position.z));

            if (distance < 20 && distance > 15)
            {
                Controller.SecunradyFire = true;
            }
            else
            {
                Controller.SecunradyFire = false;
            }
        }else
        {
            Controller.SecunradyFire = false;
        }
    }

    public virtual void UpdatePhysic()
    {
         
    }
}
