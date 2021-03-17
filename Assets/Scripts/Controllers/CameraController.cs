using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : BaseStateController
{
    #region Behaviors

    [SerializeField] private ScriptableObject _zoom;

    [SerializeField] private ScriptableObject _displacement;

    [SerializeField] private ScriptableObject _shaking;

    [SerializeField] private ScriptableObject _waiting;
    #endregion
     

    #region PRIVATE VARIABLES

    private Dictionary<CameraBehavior, IState> _behaviuos = new Dictionary<CameraBehavior, IState>(); 

    [SerializeField] private Transform _camera;

    [SerializeField] private CameraData _data;
    #endregion
     
    private void Start()
    {
        SetupBehavious();

        ChangeState(GetBehavious(CameraBehavior.DISPLACEMENT));
    }

    private void Update()
    { 

        var keyBoard = Keyboard.current;

        if (keyBoard != null)
        {
            if (keyBoard.eKey.wasPressedThisFrame)
            {
                ChangeState(GetBehavious(CameraBehavior.SHAKING));
            }
        }
    }

    #region OWN METHODS 

    private void SetupBehavious()
    {
        _behaviuos.Add(CameraBehavior.DISPLACEMENT,(IState)_displacement);

        _behaviuos.Add(CameraBehavior.WAITING, (IState)_waiting);

        _behaviuos.Add(CameraBehavior.SHAKING, (IState)_shaking);

        _behaviuos.Add(CameraBehavior.ZOOM, (IState)_zoom); 
    }

    public IState GetBehavious(CameraBehavior behavior)
    {
        return _behaviuos[behavior];
    }

    public Transform GetCameraTransform()
    {
        return _camera;
    }  

    public CameraData GetData()
    {
        return _data;
    }
    #endregion
}
