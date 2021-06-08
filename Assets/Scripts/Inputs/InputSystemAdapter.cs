using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemAdapter : IInputSelection
{
    private Inputs _inputs;

    private bool _gameplayer;  

    public InputSystemAdapter(int id, int amountPlayer, bool gameplayer = true)
    {
        _inputs = new Inputs();

        _gameplayer = gameplayer;

        _inputs.Tank.Enable();

        _inputs.bindingMask = InputBinding.MaskByGroup($"Player{GetPlayerName(id)}");

        if(amountPlayer == 1)
        {
            if(Gamepad.all.Count == 1)
            { 
                _inputs.devices = new InputDevice[] { Keyboard.current, Gamepad.current };
            }
            else
            {
                _inputs.devices = new InputDevice[] { Keyboard.current};
            }
        }else if(amountPlayer == 2)
        {
            if(id == 0)
            {
                _inputs.devices = new InputDevice[] { Keyboard.current };
            }
            else
            {
                if (Gamepad.all.Count == 1)
                {
                    _inputs.devices = new InputDevice[] { Keyboard.current, Gamepad.current };
                }
                else
                {
                    _inputs.devices = new InputDevice[] { Keyboard.current };
                }
            } 
        }
    }
     

    private string GetPlayerName(int id)
    {  
        if(id == 0)
        {
            return "One";
        }else if(id == 1)
        {
            return "Two";
        }
        else
        {
            return "";
        }
    }
    public Vector2 GetMotionDirection()
    {
        Vector2 finalPos = _inputs.Tank.Move.ReadValue<Vector2>();

        finalPos.x *= 2;

        return finalPos;
    }

    public bool PrimaryShoot()
    {
        if (_gameplayer)
        { 
            return _inputs.Tank.FirePrimary.ReadValue<float>() > 0;
        }
        return _inputs.Selection.FirePrimary.triggered;
    }

    public bool SecundaryShoot()
    {
        if (_gameplayer)
        {
            return _inputs.Tank.FireSecundary.ReadValue<float>() > 0;
        }
        return _inputs.Selection.FirePrimary.triggered;
    }

    public bool Left()
    {
        return _inputs.Selection.Left.triggered;
    }

    public bool Right()
    {
        return _inputs.Selection.Right.triggered;
    }

    public void Disable()
    {
        _inputs.Disable();
    }

    public void Enable()
    {
        _inputs.Enable();
    }
}
