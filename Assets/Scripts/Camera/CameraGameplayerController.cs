using System.Collections.Generic;
using UnityEngine;

public class CameraGameplayerController : MonoBehaviour, ISubject<int>
{
    #region Private variable

    private List<IObserver<int>> _observers = new List<IObserver<int>>();

    [SerializeField] private GameData _data; 

    [SerializeField] private HudController _hudPrefab;
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    private void Start()
    {
        UpdateObservers(_data.NPlayer);

        SetupCameras();
    }

    #endregion

    #region Own Methods
    private void SetupCameras()
    {
        CameraStateMachine[] cameras = FindObjectsOfType<CameraStateMachine>();

        foreach (var item in cameras)
        {
            HudController hud = Instantiate(_hudPrefab);

            Tank player = item.GetComponent<Tank>();

            player.Register(hud);

            player._eventUpdateAmmunitionPrimary += hud.UpdateAmmunitionPrimary;

            player._eventUpdateAmmunitionSecundary += hud.UpdateAmmunitionSecundary;

            player._eventUpdateCdPrimary += hud.UpdateCdPrimary;

            player._eventUpdateCdSecundary += hud.UpdateCdSecundary;

            hud.GetComponent<Canvas>().worldCamera = item.MainCamera;

            hud.GetComponent<Canvas>().planeDistance = 1;
        }
    }
    public void Register(IObserver<int> Observer)
    {
        _observers.Add(Observer);
    }

    public void Remove(IObserver<int> Observer)
    {
        _observers.Remove(Observer);
    }

    public void UpdateObservers(int mensage)
    {
        foreach (var item in _observers)
        {
            item.Notify(mensage);
        }
    }
    #endregion

} 
