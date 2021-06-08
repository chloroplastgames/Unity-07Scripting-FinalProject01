using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Prototipo/Data/GameData")]
public class GamePlayerData : ScriptableObject
{
    [SerializeField] private int _nPlayer;
    [SerializeField] private int _nAI; 
    [SerializeField] private List<PlayerTank> _playerTanks;

    public int NPlayer { get => _nPlayer; set => _nPlayer = value; }
    public int NAI { get => _nAI; set => _nAI = value; }
    public List<PlayerTank> PlayerTanks { get => _playerTanks; set => _playerTanks = value; }
}
