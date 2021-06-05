using UnityEngine;

public class MainMenuController : MonoBehaviour, IMainMenu, IMainMenuEvents
{
    public ISubject<ButtonPvsPEventArgs> ButtonPvsPSubject => buttonPvsPSubject;
    public ISubject<ButtonPvsCPUEventArgs> ButtonPvsCPUSubject => buttonPvsCPUSubject;
    public GameObject CanvasMainMenu => canvasMainMenu;

    [SerializeField] private GameObject canvasMainMenu;

    private ISubject<ButtonPvsPEventArgs> buttonPvsPSubject;
    private ISubject<ButtonPvsCPUEventArgs> buttonPvsCPUSubject;

    private void Awake()
    {
        buttonPvsPSubject = GetComponent<ISubject<ButtonPvsPEventArgs>>();
        buttonPvsCPUSubject = GetComponent<ISubject<ButtonPvsCPUEventArgs>>();
    }
}