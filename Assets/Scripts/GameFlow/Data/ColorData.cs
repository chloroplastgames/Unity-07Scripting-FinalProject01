using UnityEngine;

[CreateAssetMenu(fileName = "NewColor", menuName = "ScriptableObject/GameFlow/Color/SingleColor")]
public class ColorData : ScriptableObject
{
    public string ColorName => colorName;
    public Color Color => color;

    [SerializeField] private string colorName;
    [SerializeField] private Color color;
}