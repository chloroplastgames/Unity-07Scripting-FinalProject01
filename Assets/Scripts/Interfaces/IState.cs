using System.Collections;
using UnityEngine;
public interface IState
{  
    IEnumerator Enter();

    void StateUpdate();

    IEnumerator Exit(); 
}
