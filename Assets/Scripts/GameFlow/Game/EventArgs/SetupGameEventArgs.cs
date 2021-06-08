using UnityEngine;

public struct SetupGameEventArgs
{
    public readonly GameObject agent1Instance;
    public readonly GameObject agent2Instance;

    public SetupGameEventArgs(GameObject agent1Instance, GameObject agent2Instance)
    {
        this.agent1Instance = agent1Instance;
        this.agent2Instance = agent2Instance;
    }
}