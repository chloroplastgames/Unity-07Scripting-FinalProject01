using UnityEngine;
using UnityEngine.UI;

public class ButtonExitBehaviour : MonoBehaviour
{
    [SerializeField] private Button buttonExit;

    private void OnEnable()
    {
        buttonExit.onClick.AddListener(() => OnButtonExitClick());
    }

    private void OnDisable()
    {
        buttonExit.onClick.RemoveAllListeners();
    }

    private void OnButtonExitClick()
    {
        ExitGame();
    }

    private void ExitGame()
    {
        print("Exit game");
        Application.Quit();
    }
}