﻿using UnityEngine;

public class InactivePlayerState : State
{
    private readonly GameObject myGameObject;

    public InactivePlayerState(
        IStateController controller,
        GameObject myGameObject
        ) : base(controller)
    {
        this.myGameObject = myGameObject;
    }

    public override void Enter()
    {
        base.Enter();

        myGameObject.SetActive(false);
    }

    public override void Update()
    {
        return;
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        base.Exit();
    }
}