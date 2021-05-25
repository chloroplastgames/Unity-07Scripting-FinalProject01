using UnityEngine;

public class LookAtTargetBehaviour : MonoBehaviour, ILookAtTarget
{
    [SerializeField] private float speed = 2f;

    public Vector3 LookAtTarget(Transform target)
    {
        Vector3 directionNormalized = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionNormalized.x, 0, directionNormalized.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, speed * Time.deltaTime);

        return directionNormalized;
    }
}