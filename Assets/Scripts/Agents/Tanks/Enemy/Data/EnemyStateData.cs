using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStateData", menuName = "ScriptableObject/EnemyStateData")]
public class EnemyStateData : ScriptableObject
{
    public int VisionRange => visionRange;

    [SerializeField] private int visionRange = 20;
}