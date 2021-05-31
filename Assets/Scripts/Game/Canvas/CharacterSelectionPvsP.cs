using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionPvsP : MonoBehaviour
{
    // Colors enumerable
    // Public interface
    // Reset

    public RawImage Player1Background => player1Background;
    public GameObject Player1Tank => player1Tank;
    public Text Player1Text => player1ColorText;

    public RawImage Player2Background => player2Background;
    public GameObject Player2Tank => player2Tank;
    public Text Player2Text => player2ColorText;

    [SerializeField] private RawImage player1Background;
    [SerializeField] private GameObject player1Tank;
    [SerializeField] private Text player1ColorText;

    [SerializeField] private RawImage player2Background;
    [SerializeField] private GameObject player2Tank;
    [SerializeField] private Text player2ColorText;
}