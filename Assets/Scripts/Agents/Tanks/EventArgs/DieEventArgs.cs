using UnityEngine;

public struct DieEventArgs
{
    public readonly GameObject agentInstance;

    public DieEventArgs(GameObject agentInstance)
    {
        this.agentInstance = agentInstance;
    }
}