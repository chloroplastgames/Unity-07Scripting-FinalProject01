using UnityEngine;

// SHOW

public class GameOverController : MonoBehaviour, IGameOver, IGameOverEvents, IObserver<GameWinnerEventArgs>
{
    public ISubject<ButtonRestartEventArgs> ButtonRestartSubject => buttonRestartSubject;

    public GameObject CanvasGameOver => canvasGameOver;

    [SerializeField] private GameObject canvasGameOver;

    private ISubject<ButtonRestartEventArgs> buttonRestartSubject;
    private ShowWinnerBehaviour showWinner;

    private GameController gameController;

    private void Awake()
    {
        buttonRestartSubject = GetComponent<ISubject<ButtonRestartEventArgs>>();
        showWinner = GetComponent<ShowWinnerBehaviour>();

        gameController = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        gameController.GameWinnerSubject.Add(this);
    }

    private void Start()
    {
        canvasGameOver.SetActive(false);
    }

    private void OnDisable()
    {
        gameController.GameWinnerSubject.Remove(this);
    }

    public void OnNotify(GameWinnerEventArgs gameWinnerEventArgs)
    {
        if (gameWinnerEventArgs.gameWinner.instance == null) return;

        ShowWinner(gameWinnerEventArgs.gameWinner);
    }

    private void ShowWinner(GameWinner winner)
    {
        showWinner.ShowWinner(winner);
    }
}