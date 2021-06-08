using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionTank : MonoBehaviour,ISubject<SelectedTank>
{
    #region Private variable
    private IInputSelection _inputs;

    private TankSelector[] _allTanks;

    private int _currentTank;

    private int _id;

    private List<IObserver<SelectedTank>> _observes = new List<IObserver<SelectedTank>>();

    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    private void Awake()
    {  
        _allTanks = FindObjectsOfType<TankSelector>(); 
    }
    private void Update()
    {
      if(_inputs != null)
        {
            SelectedTank mensage = null;

            if (_inputs.Left())
            {
                mensage = new SelectedTank(_id, TypeAction.DESELECT, _currentTank); 

                if (_currentTank != 0)
                { 
                    _currentTank--;
                }
                else
                { 
                    _currentTank = _allTanks.Length - 1;
                }

                mensage = new SelectedTank(_id, TypeAction.SELECT,_currentTank);

                UpdateObservers(mensage);
            }
            if (_inputs.Right())
            {
                mensage = new SelectedTank(_id, TypeAction.DESELECT, _currentTank);

                if (_currentTank != _allTanks.Length - 1)
                {  
                    UpdateObservers(mensage);

                    _currentTank++;
                }
                else
                {
                    _currentTank = 0;
                }

                mensage = new SelectedTank(_id, TypeAction.SELECT,_currentTank); 
                UpdateObservers(mensage);
            }
            if (_inputs.PrimaryShoot())
            {
                mensage = new SelectedTank(_id, TypeAction.READY);

                UpdateObservers(mensage);
            }
        }
    }
    private void OnEnable()
    {
        if (_inputs == null) return;

        _inputs.Enable();
    }

    private void OnDisable()
    {
        if (_inputs == null) return;

        _inputs.Disable();
    }
    #endregion

    #region Own Methods
    public void SetupID(int id, int amountPlayer)
    {
        _id = id;

        _inputs = new InputSystemAdapter(_id,amountPlayer, false);

        _inputs.Enable(); 

        SelectedTank mensage = new SelectedTank(_id, TypeAction.SELECT,0);

        UpdateObservers(mensage);
    }

    public void Register(IObserver<SelectedTank> Observer)
    {
        _observes.Add(Observer);
    }

    public void Remove(IObserver<SelectedTank> Observer)
    {
        _observes.Remove(Observer);
    }

    public void UpdateObservers(SelectedTank mensage)
    {
        foreach (var item in _observes)
        {
            item.Notify(mensage);
        }
    }
    #endregion

}
