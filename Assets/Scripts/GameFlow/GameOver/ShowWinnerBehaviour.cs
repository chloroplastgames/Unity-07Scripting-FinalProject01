using UnityEngine;
using UnityEngine.UI;

public class ShowWinnerBehaviour : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private Text title;
    [SerializeField] private GameObject tank;

    public void ShowWinner(GameWinner winner)
    {
        background.color = winner.color;
        title.text = winner.name.ToUpper() + " WINS!";
        UtilityFunctionsHelper.ColorGameObject(tank, winner.color);
    }
}