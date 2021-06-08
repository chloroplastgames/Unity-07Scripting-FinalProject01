using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStateMachine : GenericStateMachine<BehaviorTank>, IInput 
{
    #region Private variable

    #endregion

    #region Public variable

    public Vector2 Direction;

    public Vector2 FinalPos;

    public bool PrimaryFire;

    public bool SecunradyFire;

    #endregion

    #region Unity Methods
    private void Start()
    {
        ChangeBehavior(BehaviorTank.SEARCH);
    } 
    #endregion

    #region Own Methods
    public Vector2 GetMotionDirection()
    {
        return Direction;
    }

    public bool PrimaryShoot()
    {
        return PrimaryFire;
    }

    public bool SecundaryShoot()
    {
        return SecunradyFire;
    }

    public override void SetupBehaviors()
    {
        IState Search = new IASearch(this);

        IState Move = new IAMove(this);

        _behaviors.Add(BehaviorTank.SEARCH, Search);

        _behaviors.Add(BehaviorTank.MOVE, Move);
    }

    public void Disable()
    { 
    }

    public void Enable()
    { 

    } 
    #endregion
}

public enum BehaviorTank
{
    SEARCH,
    MOVE
}
