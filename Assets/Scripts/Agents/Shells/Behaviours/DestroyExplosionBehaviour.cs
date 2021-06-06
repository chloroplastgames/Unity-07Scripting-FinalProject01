using UnityEngine;

public class DestroyExplosionBehaviour : MonoBehaviour, IKillable
{
    [SerializeField] private ParticleSystem shellExplosion;

    public void Kill()
    {
        ParticleSystem shellExplosionInstance = Instantiate(shellExplosion, transform.position, transform.rotation);
        shellExplosionInstance.Play();
        Destroy(shellExplosionInstance.gameObject, shellExplosion.main.duration);

        Destroy(gameObject);
    }
}