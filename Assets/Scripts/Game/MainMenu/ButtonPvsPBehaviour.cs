using UnityEngine;
using UnityEngine.UI;

public class ButtonPvsPBehaviour : Subject<ButtonPvsPArgs>
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
        IObserver<ButtonPvsPArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<ButtonPvsPArgs> observer in observersPhoto)
        {
            observer.OnNotify(new ButtonPvsPArgs(agents.Player1Tank, agents.Player2Tank));
        }
    }

    private void OnButtonPvsPClick()
    {
        Notify();
    }
}