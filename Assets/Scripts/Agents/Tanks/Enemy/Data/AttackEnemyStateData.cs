using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackEnemyStateData", menuName = "ScriptableObject/AttackEnemyStateData")]
public class AttackEnemyStateData : ScriptableObject
{
    public float TimeBetweenAttacks => timeBetweenAttacks;
    public float MinTimeToDodge => minTimeToDodge;
    public float MaxTimeToDodge => maxTimeToDodge;
    public float RotateToShootPrecision => rotateToShootPrecision;

    [SerializeField] private float timeBetweenAttacks = 1f;
    [SerializeField] private float minTimeToDodge = 3f;
    [SerializeField] private float maxTimeToDodge = 4f;
    [SerializeField] private float rotateToShootPrecision = 5f;
}