using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackEnemyStateData", menuName = "ScriptableObject/AttackEnemyStateData")]
public class AttackEnemyStateData : ScriptableObject
{
    public float TimeBetweenAttacks => timeBetweenAttacks;

    [SerializeField] private float timeBetweenAttacks;
}