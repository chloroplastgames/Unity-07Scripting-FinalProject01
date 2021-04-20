using UnityEngine;

public class DestroyBehaviour : MonoBehaviour, IDestroy
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}