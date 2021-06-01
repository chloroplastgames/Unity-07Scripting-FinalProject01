using UnityEngine;
using UnityEngine.UI;

public class CanvasCountdown : MonoBehaviour
{
    public Text CountdownText => countdownText;

    [SerializeField] private Text countdownText;
}