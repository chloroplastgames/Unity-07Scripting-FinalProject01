using UnityEngine;
using UnityEngine.UI;

public class CanvasGameOver : MonoBehaviour
{
    public Button ButtonMenu => buttonMenu;
    public Button ButtonRestart => buttonRestart;

    [SerializeField] private Button buttonMenu;
    [SerializeField] private Button buttonRestart;
}