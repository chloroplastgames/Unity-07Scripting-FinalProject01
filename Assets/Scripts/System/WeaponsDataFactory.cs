using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsDataFactory : GenericSingleton<WeaponsDataFactory>
{
    #region Private variable
    [SerializeField] private DefaultPrimaryWeapon _defaultProjectle;

    public IWeapon GetDefaultPrimaryArmor()
    {
        return Instantiate(_defaultProjectle);
    }
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods

    #endregion

    #region Own Methods

    #endregion

}


