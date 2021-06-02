using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region Private variable

    private LoadController _loadController;

    [SerializeField] private Button _playerVsAI;

    [SerializeField] private Button _playerVsPlayer;

    [SerializeField] private Button _quit;

    [SerializeField] private GameData _data;
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    private void Awake()
    {
        _loadController = FindObjectOfType<LoadController>();

        _playerVsAI.onClick.AddListener(PlayerVsAI);

        _playerVsPlayer.onClick.AddListener(PlayerVsPlayer);

        _quit.onClick.AddListener(() => Application.Quit());
    }
    #endregion

    #region Own Methods
    private void PlayerVsAI()
    {
        _loadController.NewScene(1);
        _data.NAI = 1;
        _data.NPlayer = 1;
    }

    private void PlayerVsPlayer()
    {
        _loadController.NewScene(1); 
        _data.NAI = 0;
        _data.NPlayer = 2;
    }
    #endregion

}
