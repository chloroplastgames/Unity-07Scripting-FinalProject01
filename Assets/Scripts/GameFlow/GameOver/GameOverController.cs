using UnityEngine;

public class GameOverController : MonoBehaviour, IGameOver, IGameOverEvents
{
    public ISubject<ButtonRestartEventArgs> ButtonRestartSubject => buttonRestartSubject;

    public GameObject CanvasGameOver => canvasGameOver;

    [SerializeField] private GameObject canvasGameOver;

    private ISubject<ButtonRestartEventArgs> buttonRestartSubject;
    private ShowWinnerBehaviour winnerShower;

    private void Awake()
    {
        buttonRestartSubject = GetComponent<ISubject<ButtonRestartEventArgs>>();

        winnerShower = GetComponent<ShowWinnerBehaviour>();
    }

    public void ShowWinner()
    {
        // winnerShower.ShowWinner();
    }
}