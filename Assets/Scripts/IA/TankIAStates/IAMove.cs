using UnityEngine;

public sealed class IAMove : IAState
{
    #region PRIVATE VARIABLES

    private Collider[] _colliders;

    private LayerMask _layer;
    #endregion

    #region CONSTRUCTOR
    public IAMove(TankStateMachine controller) : base(controller)
    {
        _layer = LayerMask.GetMask("Player");
    }
    #endregion

    #region OWN METHODS
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        _colliders = Physics.OverlapSphere(_controller.transform.position, 20,_layer);

        if(_colliders.Length > 0)
        {
            _controller.Target = _colliders[0].transform;

            _controller.ChangeBehavior(IABehaviors.RUSH);
        }
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic();

        _controller.Direction = new Vector2(0, 1);
    }
    #endregion
}
