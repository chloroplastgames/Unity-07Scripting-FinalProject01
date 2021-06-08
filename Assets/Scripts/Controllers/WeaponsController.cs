using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour, IWeaponController
{
    #region Private variable

    private ITanks _tank;

    private ITanks _target;

    private IWeapon _primaryWeapon;

    private IWeapon _secundaryWeapon;

    private HudController _hud;

    [SerializeField] private Transform _tower;

    [SerializeField] private Transform _launch;
    #endregion

    #region Public variable

    public Action<float> eventPrimaryAmmo;

    public Action<float> eventSecundaryAmmo;
    public Transform Tower { get => _tower; }  
    

    public ITanks Target
    {
        get => _target;
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _tank = GetComponent<TankManager>();

        _primaryWeapon = WeaponsDataFactory.Instance.GetDefaultPrimaryArmor();

        _primaryWeapon.Setup(this); 

        _target = null;
    } 
    private void Update()
    { 
        GetTarget();

        PrimaryFire(_tank.Inputs);

        SecundaryFire(_tank.Inputs);

        TurnTower();
    } 
    #endregion

    #region Own Methods
    public void PrimaryFire(IInput input)
    {  
        if (input.PrimaryShoot())
        { 
            _primaryWeapon?.Fire(_tank.Damage, _launch); 
        } 
    }

    public void SecundaryFire(IInput input)
    { 
        if (input.SecundaryShoot())
        { 
            _secundaryWeapon?.Fire(_tank.Damage, _launch); 
        } 
    }

    public void ChangeWeapon(IWeapon NewWeapon)
    {
        _secundaryWeapon = NewWeapon;

        _secundaryWeapon.Setup(this);

        _secundaryWeapon.AmmoUpdate += _hud.UpdatePrimaryAmmo;
    }

    private void GetTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, 10, LayerMask.GetMask("Tank"));

        if (targets.Length > 1)
        {
            float currentDistance = float.MaxValue;

            foreach (var tank in targets)
            {
                float distance = Vector3.Distance(tank.transform.position, transform.position);

                if (tank.GetComponent<ITanks>() != _tank && tank.TryGetComponent(out ITanks currentTarget))
                {
                    if (currentDistance > distance)
                    {
                        currentDistance = distance;

                        _target = currentTarget;
                    }
                }
            }
        }
        else
        {
            _target = null;
        }
    } 

    private void TurnTower()
    {  
        if (_target == null)
        {
            _tower.transform.rotation = Quaternion.LookRotation(Vector3.up, -_tank.GetTransform().forward); 
        }
        else
        {
            Vector3 pos = _target.GetTransform().position;

            _tower.transform.rotation = Quaternion.LookRotation(Vector3.up, new Vector3(transform.position.x, 0, transform.position.z)
                                                            - new Vector3(pos.x, 0, pos.z));

        }
         
    } 

    public void SetupHud(HudController hud)
    {
        _hud = hud; 

        _primaryWeapon.AmmoUpdate += _hud.UpdatePrimaryAmmo;
    }
    #endregion 
}
