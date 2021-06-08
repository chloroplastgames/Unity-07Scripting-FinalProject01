using UnityEngine;

public interface ITanks:IStates
{ 
    TankData Data
    {
        get;
    }
    Teams CurrentTeam
    {
        get;
    }

    int IdPlayer
    {
        get;
    }  

    bool IA
    {
        get;
    }

    IInput Inputs
    {
        get;
    }

    void SetupTank(Teams team, int id,int amountPlayer, bool ia);

    void ApplyUpgrade(Upgrade upgrade);

    Transform GetTransform();
}
