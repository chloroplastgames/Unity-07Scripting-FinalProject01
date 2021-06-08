using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDataFactory : GenericSingleton<CameraDataFactory>
{
    #region Private variable
    [SerializeField] private Camera _mainCameraPrefab;
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods

    #endregion

    #region Own Methods

    #endregion
    public Camera GetCamera()
    {
        Camera MainCamera = Instantiate(_mainCameraPrefab);

        return MainCamera;
    }
}
