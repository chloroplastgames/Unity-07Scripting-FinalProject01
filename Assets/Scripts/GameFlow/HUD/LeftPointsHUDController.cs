using UnityEngine;
using UnityEngine.UI;

public class LeftPointsHUDController : MonoBehaviour, IObserver<PointsEventArgs>
{
    [SerializeField] private Text pointsText;

    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        gameController.Agent1PointsSubject.Add(this);
    }

    private void OnDestroy()
    {
        gameController.Agent1PointsSubject?.Remove(this);
    }

    public void OnNotify(PointsEventArgs pointsEventArgs)
    {
        UpdatePoints(pointsEventArgs.points);
    }

    private void UpdatePoints(int points)
    {
        pointsText.text = points.ToString();
    }
}