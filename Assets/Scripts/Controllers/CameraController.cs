using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour, ISubject<Rect, int>
{
    private List<IObserver<Rect, int>> _observers = new List<IObserver<Rect, int>>();

    [SerializeField] private GamePlayerData _data;

    [SerializeField] private HudController _hudPrefab;

    public HudController HudPrefab
    {
        get => _hudPrefab;
    }


    public void UpdateCamera()
    {
        Rect newRect = new Rect(0, 0, 1, 1);

        for (int i = 0; i < _data.NPlayer; i++)
        {
            if(_data.NPlayer == 1)
            {
                newRect = new Rect(0, 0, 1, 1);
            }else if(_data.NPlayer == 2)
            {
                if(i == 0)
                {
                    newRect = new Rect(0, 0, 0.5f, 1);
                }else if(i == 1)
                {
                    newRect = new Rect(0.5f, 0, 0.5f, 1);
                }
            } 
            UpdateObservers(newRect, i);
             
        }
    }
    public void Register(IObserver<Rect, int> Observer)
    {
        _observers.Add(Observer);
        UpdateCamera();
    }

    public void Remove(IObserver<Rect, int> Observer)
    {
        _observers.Remove(Observer);
    }

    public void UpdateObservers(Rect mensage, int mensage02)
    {
        foreach (var item in _observers)
        {
            item.Notify(mensage, mensage02);
        }
    }
}
