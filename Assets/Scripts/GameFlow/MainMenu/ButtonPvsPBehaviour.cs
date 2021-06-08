using UnityEngine;
using UnityEngine.UI;

public class ButtonPvsPBehaviour : Subject<ButtonPvsPEventArgs>
{
    [SerializeField] private Button buttonPvsP;
    [SerializeField] private AgentsData agents;

    private void OnEnable()
    {
        buttonPvsP.onClick.AddListener(() => OnButtonPvsPClick());
    }

    private void OnDisable()
    {
        buttonPvsP.onClick.RemoveAllListeners();
    }

    public override void Notify()
    {
        IObserver<ButtonPvsPEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<ButtonPvsPEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new ButtonPvsPEventArgs(agents.Player1Tank, agents.Player2Tank));
        }
    }

    private void OnButtonPvsPClick()
    {
        Notify();
    }
}