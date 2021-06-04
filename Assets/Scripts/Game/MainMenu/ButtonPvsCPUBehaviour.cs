using UnityEngine;
using UnityEngine.UI;

public class ButtonPvsCPUBehaviour : Subject<ButtonPvsCPUArgs>
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
        IObserver<ButtonPvsCPUArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<ButtonPvsCPUArgs> observer in observersPhoto)
        {
            observer.OnNotify(new ButtonPvsCPUArgs(agents.Player1Tank, agents.CPUTank));
        }
    }

    private void OnButtonPvsCPUClick()
    {
        Notify();
    }
}