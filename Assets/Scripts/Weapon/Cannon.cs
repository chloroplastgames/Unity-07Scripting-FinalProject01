using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour, IWeaponAdapter
{
    public float _timElapsed;

    public Tank _tanK;

    private List<Projectle> _objectPooling;

    private float _ammunitionMax = 2;

    private int _currentAmmunition;

    private IEnumerator _routina;

    [SerializeField] private float _countDown;

    [SerializeField] private AudioSource _audio;

    [SerializeField] private Projectle _projectlePrefab;

    private void Start()
    {
        _currentAmmunition = (int)_ammunitionMax;

        _tanK._eventUpdateAmmunitionSecundary?.Invoke(_currentAmmunition / _ammunitionMax);

        CreateObjectPooling(); 
    }

    private void CreateObjectPooling()
    {
        _objectPooling = new List<Projectle>();

        for (int i = 0; i < 3; i++)
        {
            Projectle projectle = Instantiate(_projectlePrefab);

            projectle.gameObject.SetActive(false);

            _objectPooling.Add(projectle);
        }
    }

    private Projectle Getobject()
    {
        foreach (var item in _objectPooling)
        {
            if (!item.isActiveAndEnabled)
            {
                item.transform.position = _tanK.CannonPosition.position; 

                item.transform.forward = _tanK.transform.forward;

                item.gameObject.SetActive(true);

                return item;
            }
        }
        Projectle projectle = Instantiate(_projectlePrefab);

        projectle.transform.position = _tanK.CannonPosition.position;

        projectle.transform.forward = _tanK.transform.forward;

        return projectle;
    }

    public void Fire(IInput inputs)
    {
        if (_timElapsed < _countDown)
        {
            _timElapsed += Time.deltaTime;
            return;
        }
        if (inputs.GetSecundaryFire() && _currentAmmunition > 0)
        {
            ShootProjectle();
        }
        else if (_currentAmmunition == 0 && _routina == null)
        {
            _routina = Reload();
            StartCoroutine(_routina);
        }
    }

    private void ShootProjectle()
    { 
        _currentAmmunition--; 

        if (_currentAmmunition == 0)
        {
            _tanK._eventUpdateCdSecundary(0);
        }

        Getobject();

        _audio.Play(); 

        _tanK._eventUpdateAmmunitionSecundary?.Invoke(_currentAmmunition / _ammunitionMax);

        _timElapsed = 0;
    } 

    private IEnumerator Reload()
    {
        float timeElapsed = 0;

        while (true)
        {
            timeElapsed += Time.deltaTime;

            _tanK._eventUpdateCdSecundary(timeElapsed / 4);

            if (timeElapsed > 4)
            {
                break;
            }
            yield return null;
        }
        _tanK._eventUpdateCdSecundary(1);

        _tanK._eventUpdateAmmunitionSecundary(1);

        _currentAmmunition = (int)_ammunitionMax;

        _routina = null;
    } 

    public void SetupPosition(Tank tank)
    {
        transform.position = tank.transform.position;

        transform.SetParent(tank.transform);

        _tanK = tank;
    }

    public GameObject Weapon()
    {
        return gameObject;
    }
}
