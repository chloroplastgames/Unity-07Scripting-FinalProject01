using UnityEngine;

[CreateAssetMenu(fileName = "NewChaseEnemyStateData", menuName = "ScriptableObject/ChaseEnemyStateData")]
public class ChaseEnemyStateData : ScriptableObject
{
    public int MinChaseDistance => minChaseDistance;
    public int MaxChaseDistance => maxChaseDistance;
    public float DestinationRemainingDistance => destinationRemainingDistance;

    [SerializeField] private int minChaseDistance = 20;
    [SerializeField] private int maxChaseDistance = 30;
    [SerializeField] private float destinationRemainingDistance = 1f;
}