using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : GenericSingleton<SelectionController>, IObserver<SelectedTank>
{
    #region Private variable

    private int _readyCount;

    [SerializeField] private GamePlayerData _dataGameplayer;

    [SerializeField] private DBTanks _data;

    [SerializeField] private ViewTank _prefabView;

    [SerializeField] private Transform _viewTransform;
    #endregion

    #region Public variable
    public DBTanks Data { get => _data; }

    public void Notify(SelectedTank mensage)
    {
        if(mensage.Action == TypeAction.SELECT)
        {
            _dataGameplayer.PlayerTanks[mensage.Player].Tank = mensage.Selected;
        }else if(mensage.Action == TypeAction.READY)
        {
            _readyCount++;

            if (_readyCount == _dataGameplayer.NPlayer)
            {
                FadeController.Instance.NewScene(1);
            }
        }
        else if(mensage.Action == TypeAction.BACK)
        {
            _readyCount--;
        }
        
    }

    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        SelectionTank[] controllers = FindObjectsOfType<SelectionTank>();

        foreach (var controller in controllers)
        {
            controller.Register(this);
        }
    }

    private void OnDisable()
    {
        SelectionTank[] controllers = FindObjectsOfType<SelectionTank>();

        foreach (var controller in controllers)
        {
            controller.Remove(this);
        }
    }
    #endregion

    #region Own Methods
    public void SetViews(int amount)
    {
        for (int i = 0; i < amount; i++)
        {   
            ViewTank view = Instantiate(_prefabView, _viewTransform, true); 

           view.SetID(i);

            GetComponents<SelectionTank>()[i].SetupID(i, amount);

            if (amount == 1)
            {
                view.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            }else if(amount == 2)
            {
                if(i == 0)
                {
                    view.GetComponent<RectTransform>().anchoredPosition = new Vector2(-480, 0);
                }
                else
                {
                    view.GetComponent<RectTransform>().anchoredPosition = new Vector2(480, 0);
                }
            }
        } 
    }
    #endregion

}
