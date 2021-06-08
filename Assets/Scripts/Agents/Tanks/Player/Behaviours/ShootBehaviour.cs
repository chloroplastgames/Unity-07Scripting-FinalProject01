using UnityEngine;

public class ShootBehaviour : MonoBehaviour, IShoot
{
    [SerializeField] private Rigidbody shellPrefab;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private float launchForce = 20f;

    public void Shoot()
    {
        Rigidbody shellInstance = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation);

        shellInstance.velocity = launchForce * fireTransform.forward;
    }
}