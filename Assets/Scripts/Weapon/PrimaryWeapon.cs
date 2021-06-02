using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PrimaryWeapon : MonoBehaviour, IWeaponAdapter
{
    public float _timElapsed;

    public Tank _tanK;

    private int _ammunitionMax = 20;

    private int _currentAmmunition;

    [SerializeField] private float _countDown;

    [SerializeField] private AudioSource _audio;

    private void Start()
    {
        _currentAmmunition = _ammunitionMax;

        _tanK._eventUpdateAmmunitionPrimary?.Invoke(_currentAmmunition / _ammunitionMax);
    }


    public void Fire(IInput inputs)
    {
        if(_timElapsed < _countDown)
        {
            _timElapsed += Time.deltaTime;
            return;
        }
        if (inputs.GetPrimaryFire() && _currentAmmunition >0)
        { 
            ShootProjectle();
        }else if(_currentAmmunition == 0)
        {
            StartCoroutine(Reload());
        }
    }

    private void ShootProjectle()
    {
        _currentAmmunition--;

        if (_currentAmmunition == 0)
        {
            _tanK._eventUpdateCdPrimary(0);
        }

        _audio.Play();

        Collider[] tanks = Physics.OverlapSphere(transform.position, 10);

        foreach (var item in tanks)
        {
            if(item.gameObject != _tanK.gameObject && item.TryGetComponent(out Tank targetTank))
            {
                float angle = Vector3.Angle(_tanK.transform.forward, (targetTank.transform.position - _tanK.transform.position).normalized);

                if(angle < 15)
                { 
                    targetTank.TakeDamage(2);
                } 
            }
        }

        _tanK._eventUpdateAmmunitionPrimary?.Invoke((float)_currentAmmunition/_ammunitionMax);

        _timElapsed = 0;  
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_tanK.transform.position, 10);
    }

    private IEnumerator Reload()
    {
        float timeElapsed = 0;
        while (true)
        {
            timeElapsed += Time.deltaTime;
            _tanK._eventUpdateCdPrimary(timeElapsed / 2);
            if (timeElapsed > 2)
            {
                break;
            }
            yield return null;
        }
        _tanK._eventUpdateCdPrimary(1);

        _tanK._eventUpdateAmmunitionPrimary(1);

        _currentAmmunition = _ammunitionMax;
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
