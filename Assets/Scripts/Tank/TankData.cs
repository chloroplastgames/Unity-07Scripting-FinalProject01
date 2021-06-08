using UnityEngine;

[CreateAssetMenu(menuName ="Prototipo/Data/TankStatus")]
public class TankData : ScriptableObject
{
    [SerializeField] private float _maxLife;

    [SerializeField] private float _speed;

    [SerializeField] private float _defense;

    [SerializeField] private float _torque;

    [SerializeField] private float _damage;

    public float MaxLife { get => _maxLife;}
    public float Speed { get => _speed;}
    public float Defense { get => _defense;}
    public float Torque { get => _torque;} 
    public float Damage { get => _damage; }
}
