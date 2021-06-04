using UnityEngine;

public class MainMenuController : MonoBehaviour, IMainMenu, IMainMenuEvents
{
    public ISubject<ButtonPvsPArgs> ButtonPvsPSubject => buttonPvsPSubject;
    public ISubject<ButtonPvsCPUArgs> ButtonPvsCPUSubject => buttonPvsCPUSubject;
    public GameObject CanvasMainMenu => canvasMainMenu;

    [SerializeField] private GameObject canvasMainMenu;

    private ISubject<ButtonPvsPArgs> buttonPvsPSubject;
    private ISubject<ButtonPvsCPUArgs> buttonPvsCPUSubject;

    private void Awake()
    {
        buttonPvsPSubject = GetComponent<ISubject<ButtonPvsPArgs>>();
        buttonPvsCPUSubject = GetComponent<ISubject<ButtonPvsCPUArgs>>();
    }
}