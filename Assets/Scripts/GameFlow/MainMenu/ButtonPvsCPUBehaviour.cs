using UnityEngine;
using UnityEngine.UI;

public class ButtonPvsCPUBehaviour : Subject<ButtonPvsCPUEventArgs>
{
    [SerializeField] private Button buttonPvsCPU;
    [SerializeField] private AgentsData agents;

    private void OnEnable()
    {
        buttonPvsCPU.onClick.AddListener(() => OnButtonPvsCPUClick());
    }

    private void OnDisable()
    {
        buttonPvsCPU.onClick.RemoveAllListeners();
    }

    public override void Notify()
    {
        IObserver<ButtonPvsCPUEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<ButtonPvsCPUEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new ButtonPvsCPUEventArgs(agents.Player1Tank, agents.CPUTank));
        }
    }

    private void OnButtonPvsCPUClick()
    {
        Notify();
    }
}