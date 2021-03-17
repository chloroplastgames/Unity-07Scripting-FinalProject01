using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Prototype/Data/Tank")]
public class TankData : ScriptableObject
{
    [SerializeField] private Speed _speed;

    [SerializeField] private FirePower _firePower;

    [SerializeField] private Shield _shield;

    [SerializeField] private Sprite _iconSelect;

    [SerializeField] private string _name;

    public Speed Speed { get => _speed; }

    public FirePower FirePower { get => _firePower; }

    public Shield Shield { get => _shield; }

    public string Name { get => _name; }
}
