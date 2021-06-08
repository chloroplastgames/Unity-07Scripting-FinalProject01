using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : GenericSingleton<FieldController>
{
    #region Private variable
    private float _time = 15;
    [SerializeField] private MeshRenderer _fiel;
    [SerializeField] private List<Upgrade> _upgrades;
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    private void Update()
    {
        _time += Time.deltaTime;

        if(_time > 15)
        {
            SpawnUpgrades();
            _time = 0;
        }
    } 
    #endregion

    #region Own Methods
    public Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range((-_fiel.bounds.size.x / 2)+20, (_fiel.bounds.size.x / 2) - 20), Random.Range((-_fiel.bounds.size.z / 2)+20, (_fiel.bounds.size.z / 2) - 20));
    }

    public void SpawnUpgrades()
    {
        Upgrade update = Instantiate(_upgrades[Random.Range(0, _upgrades.Count)]);
        Vector3 pos = GetRandomPosition();
        pos.z = pos.y;
        pos.y = -30;
        update.transform.position = pos;
    }
    #endregion

}
