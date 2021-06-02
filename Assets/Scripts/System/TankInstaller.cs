using System.Collections.Generic;
using UnityEngine;

public class TankInstaller : MonoBehaviour
{
    #region Private variable
    [SerializeField] private List<Tank> _prefab;

    [SerializeField] private Transform[] _posPlayer; 

    [SerializeField] private GameData _data; 
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    private void Start()
    { 
  
        List<Transform> _currentPos = new List<Transform>(_posPlayer);
 
        for (int i = 0; i < _data.NPlayer; i++)
        {
            int random = random = Random.Range(0, _currentPos.Count);

            MotionControllerPlayer controller = new MotionControllerPlayer();


            Tank player = Instantiate(_prefab[_data.PlayerTank[i]], _currentPos[random].position, Quaternion.identity);

            player.Id = i;

            player.gameObject.AddComponent<CameraStateMachine>();

            player.InstallController(controller, new InputPlayer(i));

            _currentPos.RemoveAt(random);
        } 

        for (int i = 0; i < _data.NAI; i++)
        {
            int random = random = Random.Range(0, _currentPos.Count);

            MotionControllerPlayer controller = new MotionControllerPlayer(); 

            Tank player = Instantiate(_prefab[Random.Range(0,_prefab.Count)], _currentPos[random].position, Quaternion.identity); 

            _currentPos.RemoveAt(random);

            TankStateMachine IA = player.gameObject.AddComponent<TankStateMachine>(); 

            player.InstallController(controller, IA);
        }
    }
    #endregion

    #region Own Methods

    #endregion

}
