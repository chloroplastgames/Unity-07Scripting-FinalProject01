using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName ="Prototipo/Data/SpritesTanks")]
public sealed class SelectionData: ScriptableObject
{
    [SerializeField] private List<Sprite> _tanksSprites;

    public List<Sprite> TanksSprites { get => _tanksSprites; set => _tanksSprites = value; }
}
