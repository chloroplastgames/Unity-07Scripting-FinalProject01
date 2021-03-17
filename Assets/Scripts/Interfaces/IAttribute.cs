public interface IAttribute  
{
    int GetPrimaryAttribute();

    void SetBonus(IBonus bonus);

    void RemoveBonus(IBonus bonus);
}
