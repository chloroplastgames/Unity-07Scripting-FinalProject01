using UnityEngine;

public class DestroyExplosionBehaviour : MonoBehaviour, IKillable
{
    [SerializeField] private ParticleSystem explosionParticles;
    [SerializeField] private AudioSource explosionAudio;

    public void Kill()
    {
        explosionParticles.transform.parent = null;
        explosionParticles.Play();
        explosionAudio.Play();
        Destroy(explosionParticles.gameObject, explosionParticles.main.duration);

        Destroy(gameObject);
    }
}