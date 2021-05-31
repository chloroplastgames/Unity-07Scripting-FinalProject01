using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public RawImage Background => background;
    public Text WinnerText => winnerText;
    public GameObject Tank => tank;
    public Button ButtonMenu => buttonMenu;
    public Button ButtonRestart => buttonRestart;

    [SerializeField] private RawImage background;
    [SerializeField] private Text winnerText;
    [SerializeField] private GameObject tank;
    [SerializeField] private Button buttonMenu;
    [SerializeField] private Button buttonRestart;
}