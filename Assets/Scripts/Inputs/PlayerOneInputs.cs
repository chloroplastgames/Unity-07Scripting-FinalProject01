using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PlayerOneInputs : IPlayerInput
{
    private Actions _actions;
    private Vector2 _direction;
    private bool _primary;
    private bool _secundary;
    private bool _special;
    public PlayerOneInputs()
    {
        _actions = new Actions();

        _actions.PlayerOne.Enable();

        _actions.PlayerOne.Moviment.performed += ctx =>
        {
            _direction = ctx.ReadValue<Vector2>();
        };
        _actions.PlayerOne.FirePrimary.performed += ctx =>
        {
            if (ctx.performed)
            {
                _primary = true;
            }
            else
            {
                _primary = false;
            } 
        };
    }

    public void Disable()
    {
        _actions.PlayerOne.Disable();
    }

    public void Enable()
    {
        _actions.PlayerOne.Enable();
    }

    public Vector3 GetDirection()
    {
        Vector3 final = new Vector3(_direction.x, 0, _direction.y);

        final = (final.sqrMagnitude > 1) ? final.normalized : final;

        return final;
    }

    public bool PrimaryFire()
    { 
        return _primary;
    }

    public bool SecundaryFire()
    {
        throw new System.NotImplementedException();
    }
}
