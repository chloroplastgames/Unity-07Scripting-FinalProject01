using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateController : MonoBehaviour, IStateController
{
    protected readonly Dictionary<Type, IState> states = new Dictionary<Type, IState>();

    protected IState currentState;

    public void SwitchState<T>() where T : IState
    {
        currentState?.Exit();
        IState nextState = states[typeof(T)];
        currentState = nextState;
        currentState.Enter();
    }
}