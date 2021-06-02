using UnityEngine;
using System.Collections.Generic;

public class SelectionController : MonoBehaviour,IObserver<SelectedTank>
{
    #region Private variable
    private Dictionary<int, bool> _ready = new Dictionary<int, bool>();

    private IObserver<SelectedTank>[] _tankView;

    private List<IViewController> _controllers = new List<IViewController>();

    private TankSelector[] _allSeletores;

    [SerializeField] private SelectionData _dataSelection;

    [SerializeField] private GameData _data;

    [SerializeField] private ViewTank _prefabView;

    [SerializeField] private Transform _parentViews;
    #endregion

    #region Public variable
    public SelectionData DataSelection { get => _dataSelection; }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _allSeletores = FindObjectsOfType<TankSelector>(); 
    }
    private void Start()
    {
         
        _data.PlayerTank = new List<int>();

        SetupView(_data.NPlayer);

        SetupController(_data.NPlayer); 
    }
    #endregion

    #region Own Methods
    private void SetupView(int amount)
    {
        for (int i = 0; i < amount; i++)
        { 
            ViewTank view = Instantiate(_prefabView, _parentViews, true);

            view.SetID(i);

            OrganizeViews(view, i, amount);
        }
    }

    private void OrganizeViews(ViewTank view, int i, int amount)
    {
        if(amount == 1){
            RectTransform rectransformView = view.transform as RectTransform;

            rectransformView.anchoredPosition = new Vector2(0, 0);
        }else if(amount == 2)
        {
            if(i == 0)
            {
                RectTransform rectransformView = view.transform as RectTransform;

                rectransformView.anchoredPosition = new Vector2(-480, 0);
            }
            else
            {
                RectTransform rectransformView = view.transform as RectTransform;

                rectransformView.anchoredPosition = new Vector2(480, 0);
            }
        }
    }

    private void SetupController(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            IViewController player = new InputPlayer(i, _allSeletores.Length);

            player.Register(this);

            _ready[i] = false;

            _data.PlayerTank.Add(0);

            _tankView = FindObjectsOfType<ViewTank>();

            for (int j = 0; j < _tankView.Length; j++)
            {
                player.Register(_tankView[j]);
            }

            for (int j = 0; j < _allSeletores.Length; j++)
            {
                player.Register(_allSeletores[j]); 
                
            }
            _controllers.Add(player);
        }
    }

    public void Notify(SelectedTank mensage)
    {
        if(mensage.Action == TypeAction.READY)
        {
            _ready[mensage.Player] = true; 

            foreach (var item in _ready.Values)
            {
                if (item == false) return;
            }
            FindObjectOfType<LoadController>().NewScene(2);

            foreach (var item in _controllers)
            {
                item.Desative();
            }
        }
        else if(mensage.Action == TypeAction.BACK)
        {
            _ready[mensage.Player] = false;
        }else if(mensage.Action == TypeAction.SELECT)
        {
            _data.PlayerTank[mensage.Player] = mensage.Selected;
        }
    }
    #endregion

}
