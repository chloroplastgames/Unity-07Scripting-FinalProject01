using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region Private variable

    [SerializeField] private Transform _pointA;

    [SerializeField] private Transform _pointB;

    [SerializeField] private Button _playerVsAI;

    [SerializeField] private Button _playerVsPlayer;

    [SerializeField] private GamePlayerData _data;

    [SerializeField] private Camera _camera;

    [SerializeField] private CanvasGroup _startMenu;

    [SerializeField] private CanvasGroup _selectionMenu;
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    private void Awake()
    {
        _playerVsAI.onClick.AddListener(PlayerVsAI);

        _playerVsPlayer.onClick.AddListener(PlayerVsPlayer); 
    }

    private void Start()
    { 
        AudioController.Instance.PlayAudio(0);
    }
    #endregion

    #region Own Methods
    private void PlayerVsAI()
    {
        _data.NAI = 1;

        _data.NPlayer = 1;

        StartCoroutine(MoveCamera(_pointB, 1));

        SelectionController.Instance.SetViews(_data.NPlayer);
    }

    private void PlayerVsPlayer()
    {
        _data.NAI = 0;

        _data.NPlayer = 2;

        StartCoroutine(MoveCamera(_pointB, 1));

        SelectionController.Instance.SetViews(_data.NPlayer); 
    }

    private IEnumerator MoveCamera(Transform point, float time)
    {
        float _timeElapsed = 0;

        Vector3 _startPosition = _camera.transform.position;

        Quaternion _startRotation = _camera.transform.rotation; 

        if(point == _pointB)
        {
            _startMenu.alpha = 0;
            _startMenu.blocksRaycasts = false;
            _startMenu.interactable = false;
        }
        else
        {
            _selectionMenu.alpha = 0;
            _selectionMenu.blocksRaycasts = false;
            _selectionMenu.interactable = false;
        }

        while (true)
        {
            _timeElapsed += Time.deltaTime;

            _camera.transform.position = Vector3.Lerp(_startPosition, point.position, _timeElapsed/time);

            _camera.transform.rotation = Quaternion.Lerp(_startRotation, point.rotation, _timeElapsed / time);

            if(_timeElapsed > time)
            {
                if(point == _pointB)
                { 
                    _selectionMenu.alpha = 1;
                    _selectionMenu.blocksRaycasts = true;
                    _selectionMenu.interactable = true;
                }
                else
                {
                    _startMenu.alpha = 1;
                    _startMenu.blocksRaycasts = true;
                    _startMenu.interactable = true;
                }

                yield break;
            } 
            yield return null;
        }
    }
    #endregion

}
