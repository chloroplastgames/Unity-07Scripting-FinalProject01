using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer: IInput,IViewController 
{
    #region Private variable

    private InputsController _inputsGameplayer;

    private List<IObserver<SelectedTank>> _observes;

    private int _playerId;

    private int _currentTank;

    private int _amountTanks;
    #endregion

    #region Public variable 

    #endregion

    #region CONSTRUCTOR
    public InputPlayer(int player)
    { 
        _inputsGameplayer = new InputsController(); 

        string mask = $"Player{PlayerIdToString(player)}";

        _inputsGameplayer.bindingMask = InputBinding.MaskByGroup(mask);

        _inputsGameplayer.Tank.Enable();
    }

    public InputPlayer(int player, int amountTanks)
    {
        _playerId = player;

        _amountTanks = amountTanks;

        _inputsGameplayer = new InputsController();

        string mask = $"Player{PlayerIdToString(player)}";

        _inputsGameplayer.bindingMask = InputBinding.MaskByGroup(mask);

        _inputsGameplayer.Selection.Left.started += Previus;

        _inputsGameplayer.Selection.Right.started += Next;

        _inputsGameplayer.Selection.Confirm.started += Confirm;

        _inputsGameplayer.Selection.Back.started += Back; 

        _inputsGameplayer.Selection.Enable();

        _observes = new List<IObserver<SelectedTank>>(); 
    }  
    
    #endregion

    #region Own Methods

    public Vector2 GetMotionDirection()
    {
        return _inputsGameplayer.Tank.Motion.ReadValue<Vector2>();
    }

    public bool GetPrimaryFire()
    {
        return _inputsGameplayer.Tank.Fire.ReadValue<float>() != 0;
    }

    public void Next(InputAction.CallbackContext ctx)
    { 
        if(_currentTank < _amountTanks-1)
        {
            UpdateObservers(new SelectedTank(_playerId, TypeAction.DESELECT, _currentTank));
            _currentTank++;
            UpdateObservers(new SelectedTank(_playerId, TypeAction.SELECT, _currentTank));
        }
        else
        {
            UpdateObservers(new SelectedTank(_playerId, TypeAction.DESELECT, _currentTank));
            _currentTank = 0;
            UpdateObservers(new SelectedTank(_playerId, TypeAction.SELECT, _currentTank)); 
        }
    }

    public void Previus(InputAction.CallbackContext ctx)
    {
        if (_currentTank > 0)
        {
            UpdateObservers(new SelectedTank(_playerId, TypeAction.DESELECT, _currentTank));
            _currentTank--;
            UpdateObservers(new SelectedTank(_playerId, TypeAction.SELECT, _currentTank));
        }
        else{
            UpdateObservers(new SelectedTank(_playerId, TypeAction.DESELECT, _currentTank));
            _currentTank = _amountTanks-1;
            UpdateObservers(new SelectedTank(_playerId, TypeAction.SELECT, _currentTank));
        }
    }

    public void Confirm(InputAction.CallbackContext ctx)
    {
        UpdateObservers(new SelectedTank(_playerId, TypeAction.READY));
    }

    public void Back(InputAction.CallbackContext ctx)
    {
        UpdateObservers(new SelectedTank(_playerId, TypeAction.BACK));
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

    public void Desative()
    {
        _inputsGameplayer.Disable();
    } 

    private object PlayerIdToString(int player)
    {
        switch (player)
        {
            case 0:
                return "One";
            case 1:
                return "Two";
            default:
                return "";
        }
    }

    public bool GetSecundaryFire()
    {
        return _inputsGameplayer.Tank.SecundaryFire.ReadValue<float>() != 0;
    }
    #endregion
}
