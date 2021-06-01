using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject Tank1 => tank1;
    public GameObject Tank2 => tank2;
    public Color Player1Color => player1Color;
    public Color Player2Color => player2Color;

    [SerializeField] private GameObject player1Tank;
    [SerializeField] private GameObject player2Tank;
    [SerializeField] private GameObject cpuTank;

    private GameObject tank1;
    private GameObject tank2;
    private Color player1Color;
    private Color player2Color;

    public void SetPvsP()
    {
        tank1 = player1Tank;
        tank2 = player2Tank;
    }

    public void SetPvsCPU()
    {
        tank1 = player1Tank;
        tank2 = cpuTank;
    }

    public void SetPlayer1Color(Color color)
    {
        player1Color = color;
    }

    public void SetPlayer2Color(Color color)
    {
        player2Color = color;
    }
}