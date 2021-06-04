using UnityEngine;
using UnityEngine.UI;

public abstract class PointsHUDBehaviourBase : MonoBehaviour, IObserver<PointsArg>
{
    [SerializeField] private Text pointsText;

    protected ISubject<PointsArg> pointsSubject;

    protected abstract void Awake();

    protected virtual void OnEnable()
    {
        pointsSubject.Add(this);
    }

    private void OnDisable()
    {
        pointsSubject.Remove(this);
    }

    public void OnNotify(PointsArg pointsArgs)
    {
        UpdatePointsText(pointsArgs.points);
    }

    protected void UpdatePointsText(int points)
    {
        pointsText.text = points.ToString();
    }
}