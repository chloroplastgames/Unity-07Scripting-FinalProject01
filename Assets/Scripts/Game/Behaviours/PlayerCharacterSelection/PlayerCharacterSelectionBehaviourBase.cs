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
    private MeshRenderer[] meshRenderers;
    private bool ready;

    private void Awake()
    {
        meshRenderers = tank.GetComponentsInChildren<MeshRenderer>();
    }

    private void Start()
    {
        ResetSelection();
    }

    public void PreviousSelection()
    {
        index = ((index + 1) % colorList.Colors.Length + 1) % 3;
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

        ready = true;

        SaveSelection();
    }

    public bool IsReady()
    {
        return ready;
    }

    public void ResetSelection()
    {
        index = 0;
        ChangeSelection();
    }

    private void ChangeSelection()
    {
        ready = false;

        background.color = colorList.Colors[index].Color;

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material.color = colorList.Colors[index].Color;
        }

        colorName.text = colorList.Colors[index].ColorName.ToUpper();
    }

    protected abstract void SaveSelection();
}