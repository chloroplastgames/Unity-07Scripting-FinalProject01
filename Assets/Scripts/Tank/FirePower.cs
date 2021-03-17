using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FirePower : AbstractAttribute
{ 

    public int Secundary; 

    private int _bonusSecundaryValue; 

    private List<IBonus> _bonusSecundary = new List<IBonus>();

    public int GetSecundaryAttribute()
    {
        return Secundary + _bonusSecundaryValue;
    }

    public override void RemoveBonus(IBonus bonus)
    {
        base.RemoveBonus(bonus);

        foreach (IBonus currentBonus in _bonusSecundary)
        {
            if(bonus == currentBonus)
            {
                _bonusSecundary.Remove(bonus);
                UpdateBonus();
                return;
            }
        }
    }
    public override void UpdateBonus()
    {
        base.UpdateBonus();

        _bonusSecundaryValue = 0;

        foreach (IBonus currentBonus in _bonusSecundary)
        {
            _bonusSecundaryValue += currentBonus.GetBonus();
        }
    }
}
