using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractState<C> : ScriptableObject, IState where C : MonoBehaviour
{
    protected C _controller;

    
    public virtual IEnumerator Enter()
    {
        _controller = FindObjectOfType<C>();
        Debug.Log($"Entered the {GetType()}");
        yield break;
    }

    public virtual IEnumerator Exit()
    {
        Debug.Log($"Left the {GetType()}");
        yield break;
    }

    public abstract void StateUpdate();

    
}
