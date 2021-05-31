using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button ButtonPvsP => buttonPvsP;
    public Button ButtonPvsCPU => buttonPvsCPU;
    public Button ButtonExit => buttonExit;

    [SerializeField] private Button buttonPvsP;
    [SerializeField] private Button buttonPvsCPU;
    [SerializeField] private Button buttonExit;
}