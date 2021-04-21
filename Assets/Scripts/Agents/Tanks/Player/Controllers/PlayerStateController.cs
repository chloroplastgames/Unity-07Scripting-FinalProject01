﻿public class PlayerStateController : StateController
{
    private IState activePlayerState;
    private IState inactivePlayerState;

    private ITranslate translator;
    private IRotate rotator;
    private IFire shooter;

    private void Awake()
    {
        translator = GetComponent<ITranslate>();
        rotator = GetComponent<IRotate>();
        shooter = GetComponent<IFire>();

        activePlayerState = new ActivePlayerState(
            this,
            translator,
            rotator,
            shooter
            );
        inactivePlayerState = new InactivePlayerState(
            this
            );
        states.Add(typeof(ActivePlayerState), activePlayerState);
        states.Add(typeof(InactivePlayerState), inactivePlayerState);
    }

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    private void Start()
    {
        SwitchState<InactivePlayerState>();
    }
}