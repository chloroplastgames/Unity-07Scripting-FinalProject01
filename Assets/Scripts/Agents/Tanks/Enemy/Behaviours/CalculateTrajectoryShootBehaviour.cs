using UnityEngine;

public class CalculateTrajectoryShootBehaviour : MonoBehaviour, ICalculateTrajectoryShoot
{
    [SerializeField] private Rigidbody shellPrefab;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private float launchForce = 20f;
    [SerializeField] private Transform turret;
    [SerializeField] private bool isLowAngle = true;
    [SerializeField] private float maxAngleDistanceDeviation;
    [SerializeField] private float minAngleDistanceDeviation;

    private const float Gravity = 9.81f;

    public void CalculateTrajectoryShoot(Transform target)
    {
        float? angle = RotateTurret(target);

        if (angle != null)
        {
            Shoot();
        }
    }

    private float? RotateTurret(Transform target)
    {
        float? angle = CalculateAngle(target, isLowAngle);

        if (angle != null)
        {
            turret.localEulerAngles = new Vector3(360f - (float)angle, 0f, 0f);
        }

        return angle;
    }

    private float? CalculateAngle(Transform target, bool low)
    {
        Vector3 targetDirection = target.position - turret.position;
        float height = targetDirection.y;
        targetDirection.y = 0f;
        float distance = targetDirection.magnitude;
        float speedSqr = launchForce * launchForce;
        float underTheSqrt = (speedSqr * speedSqr) - Gravity * (Gravity * distance * distance + 2 * height * speedSqr);

        if (underTheSqrt >= 0f)
        {
            float root = Mathf.Sqrt(underTheSqrt);
            float highAngle = speedSqr + root;
            float lowAngle = speedSqr - root;

            if (low)
            {
                return Mathf.Atan2(lowAngle, Gravity * distance) * Mathf.Rad2Deg * GetAngleDeviation(distance);
            }
            else
            {
                return Mathf.Atan2(highAngle, Gravity * distance) * Mathf.Rad2Deg * GetAngleDeviation(distance);
            }
        }
        else
        {
            return null;
        }
    }

    private float GetAngleDeviation(float distance)
    {
        return Random.Range(minAngleDistanceDeviation, maxAngleDistanceDeviation) * distance;
    }

    private void Shoot()
    {
        Rigidbody shellInstance = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation);
        shellInstance.velocity = launchForce * turret.forward;
    }
}