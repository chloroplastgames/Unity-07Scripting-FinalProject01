using UnityEngine;

public class ShellController : MonoBehaviour
{
    private IKillable killer;

    private void Awake()
    {
        killer = GetComponent<IKillable>();
    }

    private void OnTriggerEnter()
    {
        killer.Kill();
    }
}