using System.Collections;
using UnityEngine;

public class InstallerTanks : MonoBehaviour
{
    #region Private variable 

    [SerializeField] private DBTanks _dBTanks;

    [SerializeField] private GamePlayerData _data;
    #endregion

    #region Public variable
    public GamePlayerData Data
    {
        get => _data;
    }
    #endregion

    #region Unity Methods
    private void Start()
    {
        for (int i = 0; i < _data.NPlayer; i++)
        {
            InstancePlayer(_data.PlayerTanks[i],i);
        }

        for (int i = 0; i < _data.NAI; i++)
        {
            InstanceAI(i);
        }  
    }

    private void InstanceAI(int i)
    {
        TankManager currentTank = Instantiate(_dBTanks.GetTank(Random.Range(0, _dBTanks.NTanks)));

        Vector3 pos = SetPosition();

        currentTank.transform.position = pos;

        currentTank.SetupTank(Teams.TEAM_TREE, i + 10,_data.NPlayer, true);
    }

    private void InstancePlayer(PlayerTank item,int id)
    {
        TankManager currentTank = Instantiate(_dBTanks.GetTank(item.Tank));

        Vector3 pos = SetPosition();

        currentTank.transform.position = pos;

        currentTank.SetupTank((Teams)id, id, _data.NPlayer, false);
    }

    private static Vector3 SetPosition()
    {
        Vector3 pos = FieldController.Instance.GetRandomPosition();

        pos.z = pos.y;

        pos.y = -25;

        return pos;
    }
    #endregion

    #region Own Methods

    #endregion

}
