using UnityEngine;
using UnityEngine.UI;

public class ButtonRestartBehaviour : Subject<ButtonRestartEventArgs>
{
    [SerializeField] private Button buttonRestart;

    private void OnEnable()
    {
        buttonRestart.onClick.AddListener(() => OnButtonRestartClick());
    }

    private void OnDisable()
    {
        buttonRestart.onClick.RemoveAllListeners();
    }

    public override void Notify()
    {
        IObserver<ButtonRestartEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<ButtonRestartEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new ButtonRestartEventArgs());
        }
    }

    private void OnButtonRestartClick()
    {
        Notify();
    }
}