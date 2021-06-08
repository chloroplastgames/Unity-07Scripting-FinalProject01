using UnityEngine;

public struct GameWinner
{
    public readonly GameObject instance;
    public readonly string name;
    public readonly Color color;

    public GameWinner(GameObject instance, string name, Color color)
    {
        this.instance = instance;
        this.name = name;
        this.color = color;
    }
}