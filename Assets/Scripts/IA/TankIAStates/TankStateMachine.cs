using UnityEngine;

public sealed class TankStateMachine : GenericStateMachine<IABehaviors>,IInput
{
    #region PUBLIC VARIABLES

    public Vector2 Direction;

    public Transform Target;

    public bool Fire;

    public bool FireSecundary;
    #endregion

    #region UNITY METHODS 
    private void Start()
    {
        ChangeBehavior(IABehaviors.MOVE);
    }
    private void Update()
    {
        UpdateLogic();
    }

    private void FixedUpdate()
    {
        UpdatePhysic();
    }
    #endregion

    #region OWN METHODS
    public bool GetPrimaryFire()
    {
        return Fire;
    }

    public Vector2 GetMotionDirection()
    {
        return Direction;
    }
    public override void SetupBehaviors()
    {
        IState IAMove = new IAMove(this);

        IState IARush = new IARush(this);

        IState IAStop = new IAStop(this);

        IState IAChangeDirection = new IAChangeDirection(this);

        _behaviors.Add(IABehaviors.MOVE, IAMove);

        _behaviors.Add(IABehaviors.RUSH, IARush);

        _behaviors.Add(IABehaviors.STOP, IAStop);

        _behaviors.Add(IABehaviors.CHANGE_DIRECTION, IAChangeDirection);
    }

    public bool GetSecundaryFire()
    {
        return FireSecundary;
    }
    #endregion




}
