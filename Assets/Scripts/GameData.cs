using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Prototipo/Data/Game")]
public class GameData : ScriptableObject
{
    #region Private variable

    [SerializeField] private int _nPlayer;

    [SerializeField] private int _nAI;

    [SerializeField] private List<int> _playerTank = new List<int>();
     
    #endregion

    #region Public variable
    public int NPlayer { get => _nPlayer; set => _nPlayer = value; }
    public int NAI { get => _nAI; set => _nAI = value; }
    public List<int> PlayerTank { get => _playerTank; set => _playerTank = value; }
    #endregion

} 
