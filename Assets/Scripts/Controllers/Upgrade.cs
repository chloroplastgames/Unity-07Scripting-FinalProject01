using UnityEngine;

public sealed class Upgrade : MonoBehaviour
{
    public TypeUpgrade Type;
    public float Mod;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out TankManager tank))
        {
            tank.ApplyUpgrade(this);


            Destroy(gameObject);
        } 
    }
}
