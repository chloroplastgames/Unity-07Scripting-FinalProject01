using UnityEngine;

public class ShootBehaviour : MonoBehaviour, IFire
{
    [SerializeField] private Rigidbody shellPrefab;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private float launchForce = 20f;

    public void Fire()
    {
        Rigidbody shellInstance = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation);

        shellInstance.velocity = launchForce * fireTransform.forward;
    }
}