using UnityEngine;
using UnityEngine.UI;

public class ShowWinnerBehaviour : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private Text title;
    [SerializeField] private GameObject tank;

    private const string WinText = " WINS!";

    public void ShowWinner(GameWinner winner)
    {
        background.color = winner.color;
        title.text = winner.name.ToUpper() + WinText;
        UtilityFunctionsHelper.ColorGameObject(tank, winner.color);
    }
}