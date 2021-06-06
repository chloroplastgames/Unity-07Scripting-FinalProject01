using System.Collections;
using UnityEngine;

public class CameraShakeBehaviour : MonoBehaviour, ICameraShake
{
    [SerializeField] private float duration = 0.15f;
    [SerializeField] private float magnitude = 0.4f;

    public IEnumerator ShakeRoutine()
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}