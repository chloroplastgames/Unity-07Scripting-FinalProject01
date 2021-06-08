using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T: Component
{
    #region Private variable
    private static T _instance;
    #endregion

    #region Public variable
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindInstanceOrCreate();
            }
            return _instance;
        }
    }

    private static T FindInstanceOrCreate()
    {
        var instance = FindObjectOfType<T>();

        if(instance == null)
        {
            instance = new GameObject(typeof(T).GetType().Name).AddComponent<T>(); 
        }  
        return instance;
    }
    #endregion 
}
