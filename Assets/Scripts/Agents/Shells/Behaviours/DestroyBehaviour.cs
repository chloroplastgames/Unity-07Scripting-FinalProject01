using UnityEngine;

public class DestroyBehaviour : MonoBehaviour, IKillable
{
    public void Kill()
    {
        Destroy(gameObject);
    }
}