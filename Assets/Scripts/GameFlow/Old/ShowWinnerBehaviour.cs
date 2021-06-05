using UnityEngine;
using UnityEngine.UI;

public class ShowWinnerBehaviour : MonoBehaviour, IShowWinner
{
    [SerializeField] private RawImage background;
    [SerializeField] private Text title;
    [SerializeField] private GameObject tank;

    public void ShowWinner()
    {
        GameObject winner = GameManagerSingleton.Instance.GameWinner;

        if (winner != null)
        {
            if (winner.name.Contains("Player1"))
            {
                SetCanvas(GameManagerSingleton.Instance.Agent1Color, "P1");
            }
            else if (winner.name.Contains("Player2"))
            {
                SetCanvas(GameManagerSingleton.Instance.Agent2Color, "P2");
            }
            else
            {
                SetCanvas(GameManagerSingleton.Instance.Agent2Color, "CPU");
            }
        }
    }

    private void SetCanvas(Color winnerColor, string name)
    {
        background.color = winnerColor;
        UtilityFunctionsHelper.ColorGameObject(tank, winnerColor);
        title.text = name + " WINS";
    }
}