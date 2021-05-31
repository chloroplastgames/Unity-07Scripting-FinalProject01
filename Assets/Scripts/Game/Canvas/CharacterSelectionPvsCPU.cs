using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionPvsCPU : MonoBehaviour
{
    // Colors enumerable
    // Public interface
    // Reset

    public RawImage Background => background;
    public GameObject Tank => tank;
    public Text ColorText => colorText;

    [SerializeField] private RawImage background;
    [SerializeField] private GameObject tank;
    [SerializeField] private Text colorText;
}