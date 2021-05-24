using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackEnemyStateData", menuName = "ScriptableObject/AttackEnemyStateData")]
public class AttackEnemyStateData : ScriptableObject
{
    public float RotationSpeed => rotationSpeed;
    public float TimeBetweenAttacks => timeBetweenAttacks;
    public float MinTimeToDodge => minTimeToDodge;
    public float MaxTimeToDodge => maxTimeToDodge;
    public float TimeToEscape => timeToEscape;

    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float timeBetweenAttacks = 1f;
    [SerializeField] private float minTimeToDodge = 3f;
    [SerializeField] private float maxTimeToDodge = 4f;
    [SerializeField] private int dangerZoneRadius = 2;
    [SerializeField] private float timeToEscape = 3f;
}