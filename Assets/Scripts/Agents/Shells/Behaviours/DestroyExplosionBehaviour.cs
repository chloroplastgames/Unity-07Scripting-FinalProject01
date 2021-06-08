using UnityEngine;

public class DestroyExplosionBehaviour : MonoBehaviour, IKillable
{
    [SerializeField] private ParticleSystem explosionParticles;
    [SerializeField] private AudioSource explosionAudio;

    public void Kill()
    {
        // Detach particles in order to destroy them after their duration
        explosionParticles.transform.parent = null;
        explosionParticles.Play();
        explosionAudio.Play();
        Destroy(explosionParticles.gameObject, explosionParticles.main.duration);

        // Destroy container game object
        Destroy(gameObject);
    }
}