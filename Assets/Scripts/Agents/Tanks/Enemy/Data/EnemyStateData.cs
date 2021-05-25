using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStateData", menuName = "ScriptableObject/EnemyStateData")]
public class EnemyStateData : ScriptableObject
{
    public int VisionRange => visionRange;
    public int MinDistance => minDistance;
    public int MaxDistance => maxDistance;
    public float RemainingDistance => remainingDistance;

    [SerializeField] private int visionRange = 20;
    [SerializeField] private int minDistance = 20;
    [SerializeField] private int maxDistance = 30;
    [SerializeField] private float remainingDistance = 1f;
}