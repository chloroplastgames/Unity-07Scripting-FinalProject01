using System;
using UnityEngine;

public interface IWeapon
{
    float CurrentAmount
    {
        get;
    }

    float MaxAmount
    {
        get;
    }

    Action<float> AmmoUpdate
    {
        get;
        set;
    }
    void Fire(float damageBase, Transform origin);

    void Setup(WeaponsController weaponController); 

    
}
