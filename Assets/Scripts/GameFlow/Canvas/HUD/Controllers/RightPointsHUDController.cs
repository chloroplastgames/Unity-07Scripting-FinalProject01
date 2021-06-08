using UnityEngine;
using UnityEngine.UI;

// Controller and behaviour
public class RightPointsHUDController : MonoBehaviour, IObserver<PointsEventArgs>
{
    [SerializeField] private Text pointsText;

    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        gameController.Agent2PointsSubject.Add(this);
    }

    private void OnDestroy()
    {
        gameController.Agent2PointsSubject?.Remove(this);
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