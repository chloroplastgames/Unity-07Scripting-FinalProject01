using UnityEngine;

[CreateAssetMenu(menuName ="Prototipo/Data/Tank")]
public sealed class TankData : ScriptableObject
{
    [SerializeField] private float _motionSpeed;

    [SerializeField] private float _motionAcceleration;

    [SerializeField] private float _maxLife;

    public float MotionSpeed { get => _motionSpeed; }
    public float MotionAcceleration { get => _motionAcceleration;}
    public float MaxLife { get => _maxLife; }
}
