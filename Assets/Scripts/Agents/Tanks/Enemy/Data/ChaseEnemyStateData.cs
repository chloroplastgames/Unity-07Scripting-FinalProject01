using UnityEngine;

[CreateAssetMenu(fileName = "NewChaseEnemyStateData", menuName = "ScriptableObject/ChaseEnemyStateData")]
public class ChaseEnemyStateData : ScriptableObject
{
    public int VisionRange => visionRange;
    public int MinChaseDistance => minChaseDistance;
    public int MaxChaseDistance => maxChaseDistance;

    [SerializeField] private int visionRange;
    [SerializeField] private int minChaseDistance;
    [SerializeField] private int maxChaseDistance;
}