using UnityEngine;
public sealed partial class CameraStateMachine : GenericStateMachine<CameraBehavior>,IObserver<int>
{
    #region PROPERTIES
    public Camera MainCamera
    {
        get;
        private set;
    }
    #endregion

    #region UNITY METHODS
    public override void Awake()
    {
        base.Awake();

        MainCamera = new GameObject("Camera").AddComponent<Camera>(); 
    }
    private void OnEnable()
    {
        CameraGameplayerController controller = FindObjectOfType<CameraGameplayerController>();

        if (controller != null)
        {
            controller.Register(this);
        }
    }
    private void OnDisable()
    {
        CameraGameplayerController controller = FindObjectOfType<CameraGameplayerController>();

        if(controller != null)
        {
            controller.Remove(this);
        } 
    }
    private void Start()
    {
        ChangeBehavior(CameraBehavior.NORMAL);
    }
    private void Update()
    {
        UpdateLogic(); 
    }
    private void FixedUpdate()
    {
        UpdatePhysic();
    }
    #endregion

    #region OWN METHODS
    public override void SetupBehaviors()
    {
        IState CameraMove = new CameraMoveState(this);

        IState CameraZoom = new CameraZoomState(this);

        _behaviors.Add(CameraBehavior.NORMAL, CameraMove);

        _behaviors.Add(CameraBehavior.ZOOM, CameraZoom);
    }

    public void Notify(int mensage)
    {
        switch (mensage)
        {
            case 1:
                if (GetComponent<Tank>().Id == 0)
                {
                    MainCamera.rect = new Rect(0, 0, 1, 1);
                }
                return;
            case 2:
                if (GetComponent<Tank>().Id == 0)
                {
                    MainCamera.rect = new Rect(0, 0, 0.5f, 1);
                }
                else
                {
                    MainCamera.rect = new Rect(0.5f, 0, 0.5f, 1);
                }
                return;
        }
    }
    #endregion
}
