using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text CountdownText => countdownText;

    [SerializeField] private Text countdownText;
}