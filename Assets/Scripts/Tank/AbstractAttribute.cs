using System.Collections.Generic; 

public class AbstractAttribute : IAttribute
{
    public int Primary;

    private int _bonusPrimaryValue;

    private List<IBonus> _bonusPrimary = new List<IBonus>();

    public virtual int GetPrimaryAttribute()
    {
        return Primary + _bonusPrimaryValue;
    }

    public virtual void RemoveBonus(IBonus bonus)
    {
        foreach (IBonus currentBonus in _bonusPrimary)
        {
            if (currentBonus == bonus)
            {
                _bonusPrimary.Remove(bonus);

                UpdateBonus();

                return;
            }
        }
    }

    public virtual void SetBonus(IBonus bonus)
    {
        _bonusPrimary.Add(bonus);
        UpdateBonus();
    }

    public virtual void UpdateBonus()
    {
        _bonusPrimaryValue = 0;

        foreach (IBonus currentBonus in _bonusPrimary)
        {
            _bonusPrimaryValue += currentBonus.GetBonus();
        }
    }
}
