using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackEnemyStateData", menuName = "ScriptableObject/AttackEnemyStateData")]
public class AttackEnemyStateData : ScriptableObject
{
    public float RotationSpeed => rotationSpeed;
    public float TimeBetweenAttacks => timeBetweenAttacks;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float timeBetweenAttacks;
}