using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerCharacterSelectionBehaviourBase : MonoBehaviour, IPlayerCharacterSelection
{
    [SerializeField] private RawImage background;
    [SerializeField] private GameObject tank;
    [SerializeField] private Text colorName;
    [SerializeField] private ColorListData colorList;

    protected Color colorSelected;

    private const string ReadyText = "READY!";

    private int index;

    private void Start()
    {
        ResetSelection();
    }

    public void PreviousSelection()
    {
        index = (index + (colorList.Colors.Length - 1)) % colorList.Colors.Length;
        ChangeSelection();
    }

    public void NextSelection()
    {
        index = (index + 1) % colorList.Colors.Length;
        ChangeSelection();
    }

    public void SetSelection()
    {
        colorSelected = colorList.Colors[index].Color;

        colorName.text = ReadyText;

        SaveSelection();
    }

    public void ResetSelection()
    {
        index = 0;
        ChangeSelection();
    }

    private void ChangeSelection()
    {
        background.color = colorList.Colors[index].Color;

        UtilityFunctionsHelper.ColorGameObject(tank, colorList.Colors[index].Color);

        colorName.text = colorList.Colors[index].ColorName.ToUpper();
    }

    protected abstract void SaveSelection();
}