using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour, ISubject<float>
{
    #region Private variable  

    private bool _move;

    private IInput _inputs;

    private IMotionController _motionController;

    private IWeaponAdapter _primaryWeapon;

    private IWeaponAdapter _secundaryWeapon;

    private float _currentLife;

    private List<IObserver<float>> _observers = new List<IObserver<float>>();

    [SerializeField] private TankData _data;

    [SerializeField] private Transform _CenterOfMass;

    [SerializeField] private Transform _cannonTransform;
    #endregion

    #region Public variable

    public Action<float> _eventUpdateAmmunitionPrimary;

    public Action<float> _eventUpdateCdPrimary;

    public Action<float> _eventUpdateAmmunitionSecundary;

    public Action<float> _eventUpdateCdSecundary;

    public Action _eventDead;
    public TankData Data { get => _data; }

    public Transform CannonPosition { get => _cannonTransform; }

    public bool IsDead
    {
        get
        {
            if(_currentLife == 0)
            {
                return true;
            }
            return false;
        }
    }

    public int Id
    {
        get;
        set;
    } 
     

    public Vector3 CenterOfMass
    {
        get => _CenterOfMass.localPosition;
    }
    #endregion

    #region Unity Methods 

    private void Start()
    { 
        _currentLife = _data.MaxLife;

        UpdateObservers(_currentLife);

        SetupPrimaryWeapon(FindObjectOfType<WeaponDataFactory>().GetPrimaryWeapon());

        SetupSecundaryWeapon(FindObjectOfType<WeaponDataFactory>().GetCannon());
    }

    private void OnEnable()
    {
        GameplayerController controller = FindObjectOfType<GameplayerController>();

        if(controller != null)
        {

            _eventDead += controller.CheckTanks;
        } 
    } 

    private void Update()
    {
        if (_move)
        {
            _primaryWeapon?.Fire(_inputs);
            _secundaryWeapon?.Fire(_inputs);
        }
    }
    private void FixedUpdate()
    {
        if (_move)
        { 
            _motionController.Move(_inputs);
        } 
    }

    private void OnDisable()
    {
        GameplayerController controller = FindObjectOfType<GameplayerController>();

        if (controller != null)
        {

            _eventDead -= controller.CheckTanks;
        }
    }
    #endregion

    #region Own Methods
    public void InstallController(IMotionController motionController, IInput inputs)
    {
        _inputs = inputs;

        _motionController = motionController;

        _motionController.SetupTank(this);
    }

    public void Register(IObserver<float> Observer)
    {
        _observers.Add(Observer);
    }

    public void Remove(IObserver<float> Observer)
    {
        _observers.Remove(Observer);
    }

    public void UpdateObservers(float mensage)
    {
        foreach (var item in _observers)
        {
            item.Notify(mensage);
        }
    }

    public void SetupPrimaryWeapon(IWeaponAdapter weapon)
    {
        _primaryWeapon = weapon;

        _primaryWeapon.SetupPosition(this); 
    }

    public void SetupSecundaryWeapon(IWeaponAdapter weapon)
    {
        if(_secundaryWeapon != null)
        {
            Destroy(_secundaryWeapon.Weapon()); 
        }
        _secundaryWeapon = weapon;

        _secundaryWeapon.SetupPosition(this);
    }

    public void Dead()
    { 
        Destroy(gameObject); 
        _eventDead?.Invoke();
    }

    public void SetupMotion(bool status)
    {
        _move = status;
    }

    public void TakeDamage(float damage)
    {
        if(_currentLife - damage > 0)
        {
            _currentLife -= damage; 
        }
        else
        {
            _currentLife = 0;
            Dead();
        }
        UpdateObservers(_currentLife);
    }
    #endregion
}
