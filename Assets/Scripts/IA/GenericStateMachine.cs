using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericStateMachine<T> : MonoBehaviour
{
    #region Private variable

    protected Dictionary<T, IState> _behaviors = new Dictionary<T, IState>();

    private IState _currentState;

    private bool _transition;

    [SerializeField] private bool _debug;
    #endregion

    #region Public variable
    public bool Debug { get => _debug; }
    #endregion

    #region Unity Methods
    public virtual void Awake()
    {
        SetupBehaviors();
    }
    #endregion

    #region Own Methods

    public void UpdateLogic()
    {
        if(!_transition && _currentState != null)
        {
            _currentState.UpdateLogic();
        }
    }
    public void UpdatePhysic()
    {
        if (!_transition && _currentState != null)
        {
            _currentState.UpdatePhysic();
        }
    }

    public void ChangeBehavior(T newBehavior)
    {
        _transition = true;

        if(_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = _behaviors[newBehavior];

        _currentState.Enter();

        _transition = false;
    }

    public abstract void SetupBehaviors();
    #endregion

}
