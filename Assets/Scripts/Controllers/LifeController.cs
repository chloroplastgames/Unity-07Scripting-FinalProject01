using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LifeController : MonoBehaviour,ILifeController,ISubject<Teams>
{
    #region Private variable 

    private float _currentLife;

    private ITanks _tank;

    private List<IObserver<Teams>> _observers = new List<IObserver<Teams>>();
    #endregion

    #region Public variable

    public Action<float> eventLife;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _tank = GetComponent<TankManager>();

        _currentLife = _tank.MaxLife; 
    }

    private void Start()
    { 
        UpdateHealth();
    }

    private void OnEnable()
    {
        GamePlayerController controller = FindObjectOfType<GamePlayerController>();

        if(controller != null)
        {
            Register(controller);
        }
    }

    private void OnDisable()
    {
        GamePlayerController controller = FindObjectOfType<GamePlayerController>();

        if (controller != null)
        {
            Remove(controller);
        }
    }
    #endregion

    #region Own Methods
    public void TakeDamage(float amount)
    {
        if(_currentLife - (amount-_tank.Defense) >= 0)
        {
            _currentLife -= Mathf.Clamp((amount - _tank.Defense),0,100);
        }
        else
        {
            _currentLife = 0;

            Dead();
        }
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        eventLife?.Invoke(_currentLife);
    }

    public void Dead()
    {
        UpdateObservers(GetComponent<TankManager>().CurrentTeam);

        _tank.GetTransform().gameObject.SetActive(false);
    }

    public void Recovery(float amount)
    {
        _currentLife += amount;
    }

    public void Register(IObserver<Teams> Observer)
    {
        _observers.Add(Observer);
    }

    public void Remove(IObserver<Teams> Observer)
    {
        _observers.Remove(Observer);
    }

    public void UpdateObservers(Teams mensage)
    {
        foreach (var item in _observers)
        {
            item.Notify(mensage);
        }
    }
    #endregion

}
