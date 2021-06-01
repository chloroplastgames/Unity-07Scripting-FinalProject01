using UnityEngine;

[CreateAssetMenu(fileName = "NewColorList", menuName = "ScriptableObject/Game/Color/ColorList")]
public class ColorListData : ScriptableObject
{
    public ColorData[] Colors => colors;

    [SerializeField] private ColorData[] colors;
}