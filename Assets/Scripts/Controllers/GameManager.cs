using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{ 

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _enemy; 

    public Transform GetPlayerTransform()
    {
        return _player;
    }

    public Transform GetEnemyTransform()
    {
        return _enemy;
    }
}
