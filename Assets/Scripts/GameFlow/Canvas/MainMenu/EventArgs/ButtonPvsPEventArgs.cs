using UnityEngine;

public struct ButtonPvsPEventArgs
{
    public readonly GameObject agent1;
    public readonly GameObject agent2;

    public ButtonPvsPEventArgs(GameObject agent1, GameObject agent2)
    {
        this.agent1 = agent1;
        this.agent2 = agent2;
    }
}