using System.Collections; 
using UnityEngine;

public class BaseStateController : MonoBehaviour, IStateController<BaseStateController>
{  
    private IState _currentState;

    private bool _transition; 

    public void ChangeState(IState newState)
    {
        StartCoroutine(Transition(newState));
    } 

    private void FixedUpdate()
    {
        Execute();
    }

    private void Execute()
    {
        if (!_transition && _currentState != null)
        {
            _currentState.StateUpdate();
        }
    }

    private IEnumerator Transition(IState newState)
    {
        _transition = true;

        if(_currentState != null)
        { 
            yield return StartCoroutine(_currentState.Exit());
        }

        _currentState = newState;

        yield return StartCoroutine(_currentState.Enter());

        _transition = false;

    }
}
