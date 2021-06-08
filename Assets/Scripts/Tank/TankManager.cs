using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour, ITanks
{
    #region Private variable
    private Teams _team;

    private int _id;

    private float _modDamage;

    private float _modSpeed;

    private float _modTorque;

    private float _modDefense;

    private float _modMaxLife;

    private bool _ia;

    private IInput _inputs;

    private Transform _myTransform;

    [SerializeField] private TankData _data;

    #endregion

    #region Public variable  
    public TankData Data { get => _data; }

    public float Damage { get => _data.Damage + _modDamage; }

    public float Speed { get => _data.Speed + _modSpeed; }

    public float Toquer { get => _data.Torque + _modTorque; }

    public float Defense { get => _data.Defense + _modDefense; }

    public float MaxLife { get => _data.MaxLife + _modMaxLife; }

    public IInput Inputs
    {
        get => _inputs;
    }

    public Teams CurrentTeam
    {
        get => _team;
    }

    public int IdPlayer { get => _id; }

    public bool IA
    {
        get => _ia;
        set => _ia = value;
    }
    #endregion

    #region Unity Methods 
    private void Awake()
    {
        _myTransform = transform;
    }
    #endregion

    #region Own Methods
    public Transform GetTransform()
    { 
        if(_myTransform != null)
        { 
            return _myTransform;
        }
        return null;
    }

    public void SetupTank(Teams team, int id, int amountPlayer, bool ia)
    {
        _team = team;

        _id = id;

        _ia = ia;

        if (!ia)
        {
            gameObject.AddComponent<CameraStateMachine>();

            _inputs = new InputSystemAdapter(id, amountPlayer);
        }
        else
        {
            _inputs = gameObject.AddComponent<TankStateMachine>();
        }
    }

    public void ApplyUpgrade(Upgrade upgrade)
    {
        switch (upgrade.Type)
        {
            case TypeUpgrade.DAMAGE:
                _modDamage += upgrade.Mod;
                break;

            case TypeUpgrade.DEFENSE:
                _modDefense += upgrade.Mod;
                break;

            case TypeUpgrade.HP:
                GetComponent<LifeController>().Recovery(upgrade.Mod);
                break;

            case TypeUpgrade.SPEED:
                _modSpeed += upgrade.Mod;
                break;

            case TypeUpgrade.TORQUE:
                _modTorque += upgrade.Mod;
                break;
        }
    }
    #endregion
}
