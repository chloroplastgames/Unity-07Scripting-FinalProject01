using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateController<T>
{ 
    void ChangeState(IState state);
}
