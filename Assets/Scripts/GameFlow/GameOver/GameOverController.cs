using UnityEngine;

public class GameOverController : MonoBehaviour, IGameOver, IGameOverEvents
{
    public ISubject<ButtonRestartEventArgs> ButtonRestartSubject => buttonRestartSubject;

    public GameObject CanvasGameOver => canvasGameOver;

    [SerializeField] private GameObject canvasGameOver;

    private ISubject<ButtonRestartEventArgs> buttonRestartSubject;
    private IShowWinner winnerShower;

    private void Awake()
    {
        buttonRestartSubject = GetComponent<ISubject<ButtonRestartEventArgs>>();

        winnerShower = GetComponent<IShowWinner>();
    }

    public void ShowWinner()
    {
        winnerShower.ShowWinner();
    }
}