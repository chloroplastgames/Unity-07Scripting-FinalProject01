using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DefaultPrimaryWeapon : MonoBehaviour, IWeapon
{ 

    private float _timeElapsed; 

    private List<IProjectle> _objectProjectle;

    [SerializeField] private float _timeReload;

    [SerializeField] private float _currentAmount;

    [SerializeField] private float _maxAmount;

    [SerializeField] private float _time;

    [SerializeField] private Projectle _prefabProjectle;  

    public float CurrentAmount
    {
        get => _currentAmount;
    }

    public float MaxAmount
    {
        get => _maxAmount;
    }
    public Action<float> AmmoUpdate
    {
        get;
        set;
    }

    private void Start()
    {
        _currentAmount = _maxAmount;
    }

    private void Update()
    {
        _timeElapsed += Time.deltaTime;
    }
    public void Fire(float damageBase, Transform origin)
    {
        if (_time < _timeElapsed && _currentAmount > 0)
        {
            _currentAmount--;

            AmmoUpdate?.Invoke(_currentAmount/_maxAmount);

            if(_currentAmount == 0)
            {
                StartCoroutine(StartReload());
            }
            _timeElapsed = 0;

            IProjectle projectle = GetProjectle();

            projectle.GetTransform().position = origin.transform.position;

            projectle.SetupDamage(damageBase);

            projectle.SetupDirection(transform.forward); 
        } 
    } 

    public void Setup(WeaponsController weaponController)
    {
        StartObjectPooling();

        transform.SetParent(weaponController.Tower); 
    }

    private void StartObjectPooling()
    {
        _objectProjectle = new List<IProjectle>();

        for (int i = 0; i < 3; i++)
        {
            IProjectle newProjectle = Instantiate(_prefabProjectle);

            newProjectle.Disable();

            _objectProjectle.Add(newProjectle);
        }
    }

    private IProjectle GetProjectle()
    {
        IProjectle projectle = null;

        foreach (var item in _objectProjectle)
        {
            if (!item.GetTransform().gameObject.activeInHierarchy)
            {
                projectle = item;

                projectle.Enable();

                return projectle;
            }
        }
        projectle = Instantiate(_prefabProjectle);

        _objectProjectle.Add(projectle);

        return projectle;
    }

    private IEnumerator StartReload()
    {
        yield return new WaitForSeconds(_timeReload);

        _currentAmount = _maxAmount;

        AmmoUpdate?.Invoke(1);
    }

}
