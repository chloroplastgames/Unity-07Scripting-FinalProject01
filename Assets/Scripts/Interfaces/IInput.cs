using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput  
{
    Vector2 GetMotionDirection( ); 

    bool PrimaryShoot();

    bool SecundaryShoot();

    void Disable();

    void Enable();
}

public interface IInputSelection: IInput
{  
    bool Left();

    bool Right();
}
