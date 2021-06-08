using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototipo/Data/DBTanks")]
public sealed class DBTanks : ScriptableObject
{
    [SerializeField] private List<TankManager> _tanks;
    [SerializeField] private List<Sprite> _tankSprite;
    public int NTanks { get => _tanks.Count; }
    public List<Sprite> TankSprite { get => _tankSprite;}

    public TankManager GetTank(int tank)
    {
        return _tanks[tank];
    }
}
