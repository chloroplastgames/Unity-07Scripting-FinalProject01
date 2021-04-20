using UnityEngine;

public class ShellController : MonoBehaviour
{
    private IDestroy destroyer;

    private void Awake()
    {
        destroyer = GetComponent<IDestroy>();
    }

    private void OnTriggerEnter()
    {
        destroyer.Destroy();
    }
}