using System;
using UnityEngine;

[Serializable]
public class TankManagerTemplate
{
    public int PlayerNumber { get; set; }
    public string ColoredPlayerText { get; set; }
    public GameObject Instance { get; set; }
    public int Wins { get; set; }
    public Transform SpawnPoint => spawnPoint;

    [SerializeField] private Color playerColor;
    [SerializeField] private Transform spawnPoint;

    public void Setup()
    {
        ColoredPlayerText = $"<color=#{ColorUtility.ToHtmlStringRGB(playerColor)}>PLAYER {PlayerNumber}</color>";

        MeshRenderer[] renderers = Instance.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer renderer in renderers)
        {
            renderer.material.color = playerColor;
        }
    }

    public void DisableControl()
    {
        // Event to disable control
        // Already has reference => Instance
    }

    public void EnableControl()
    {
        // Event to enable control
    }

    public void Reset()
    {
        // Event to reset
    }
}