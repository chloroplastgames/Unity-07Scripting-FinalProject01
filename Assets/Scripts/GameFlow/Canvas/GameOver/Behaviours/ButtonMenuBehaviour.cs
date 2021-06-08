using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMenuBehaviour : MonoBehaviour
{
    [SerializeField] private Button buttonMenu;

    private void OnEnable()
    {
        buttonMenu.onClick.AddListener(() => OnButtonMenuClick());
    }

    private void OnDisable()
    {
        buttonMenu.onClick.RemoveAllListeners();
    }

    private void OnButtonMenuClick()
    {
        ReloadScene();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}