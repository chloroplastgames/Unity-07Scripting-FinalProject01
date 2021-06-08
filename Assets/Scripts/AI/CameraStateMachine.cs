using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateMachine : GenericStateMachine<CameraState>, IObserver<Rect,int>
{
    #region Private variable
    public Camera MainCamera;

    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    public override void Awake()
    {
        base.Awake();

        MainCamera = CameraDataFactory.Instance.GetCamera();

        HudController hud = Instantiate(FindObjectOfType<CameraController>().HudPrefab);

        hud.SetCamera(MainCamera);

        GetComponent<WeaponsController>().SetupHud(hud);

        GetComponent<LifeController>().eventLife += hud.UpdateLife;
        
    }

    private void OnEnable()
    {
        CameraController controller = FindObjectOfType<CameraController>();

        if(controller != null)
        {
            controller.Register(this); 
        }
    }

    private void OnDisable()
    {
        CameraController controller = FindObjectOfType<CameraController>();

        if (controller != null)
        {
            controller.Remove(this);
        }
    }

    private void Start()
    {
        ChangeBehavior(CameraState.FOLLOW);
    }
    #endregion

    #region Own Methods

    #endregion
    public override void SetupBehaviors()
    {
        _behaviors.Add(CameraState.FOLLOW, new CameraFollowTank(this));
    }

    public void Notify(Rect mensage, int mensage02)
    {
        if (mensage02 != GetComponent<TankManager>().IdPlayer) return;

        MainCamera.rect = mensage;
    }
}

public enum CameraState
{
    FOLLOW
}
