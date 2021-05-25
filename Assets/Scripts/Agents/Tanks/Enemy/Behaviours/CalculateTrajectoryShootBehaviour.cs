using UnityEngine;

public class CalculateTrajectoryShootBehaviour : MonoBehaviour, ICalculateTrajectoryShoot
{
    [SerializeField] private Rigidbody shellPrefab;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private float launchForce = 20f;
    [SerializeField] private Transform turret;
    [SerializeField] private bool isLowAngle = true;

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
        float y = targetDirection.y;
        targetDirection.y = 0f;
        float x = targetDirection.magnitude;
        float gravity = 9.81f;
        float speedSqr = launchForce * launchForce;
        float underTheSqrt = (speedSqr * speedSqr) - gravity * (gravity * x * x + 2 * y * speedSqr);

        if (underTheSqrt >= 0f)
        {
            float root = Mathf.Sqrt(underTheSqrt);
            float highAngle = speedSqr + root;
            float lowAngle = speedSqr - root;

            if (low)
            {
                return Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg;
            }
            else
            {
                return Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg;
            }
        }
        else
        {
            return null;
        }
    }

    private void Shoot()
    {
        Rigidbody shellInstance = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation);
        shellInstance.velocity = launchForce * turret.forward;
    }
}