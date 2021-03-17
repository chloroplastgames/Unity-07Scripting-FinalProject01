using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITank: IDestructible
{
    TankData GetData();
    void Move(IInput input);
}
