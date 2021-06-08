using UnityEngine;

[CreateAssetMenu(fileName = "NewColorList", menuName = "ScriptableObject/GameFlow/Color/ColorList")]
public class ColorListData : ScriptableObject
{
    public ColorData[] Colors => colors;

    [SerializeField] private ColorData[] colors;
}