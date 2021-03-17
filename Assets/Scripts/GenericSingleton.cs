using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T:Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindOrCreateInstance();
            }
            return _instance;
        }
    }

    private static T FindOrCreateInstance()
    {
        T instance = FindObjectOfType<T>();
        if(instance == null)
        {
            instance = new GameObject($"{typeof(T).Name}").AddComponent<T>();
        }
        return instance;
    }
}
