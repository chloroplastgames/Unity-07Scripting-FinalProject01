using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BaseTank : MonoBehaviour, ITank
{
    private int _currentLife;

    private float _yRotation = 0;

    private CharacterController _controllerMoviment;

    [SerializeField] private TankData _data;

    public virtual void Awake()
    {
        _currentLife = _data.Shield.Primary + 3;

        _controllerMoviment = GetComponent<CharacterController>();

        _yRotation = _controllerMoviment.transform.eulerAngles.y;
    } 
    public TankData GetData()
    {
        return _data;
    }

    public void Move(IInput input)
    {
        if(_currentLife > 0)
        {
            Vector3 TankForward = _controllerMoviment.transform.TransformDirection(new Vector3(0, 0, input.GetDirection().z));

            _yRotation += input.GetDirection().x;
             
            _controllerMoviment.transform.rotation = Quaternion.Euler(new Vector3(0,_yRotation * (float)_data.Speed.Primary/2,0));

            _controllerMoviment.SimpleMove( TankForward * _data.Speed.Primary);
        }
    }

    public virtual void TakeDamage(int amount)
    {
        int RealDamage = amount - _data.Shield.GetPrimaryAttribute();

        _currentLife += (RealDamage <= 0) ? 1 : RealDamage;
    }
}
