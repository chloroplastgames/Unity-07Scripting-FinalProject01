// TODO: Merge with AttackEnemyState and ShootBehaviour

using UnityEngine;

public class CalculateTrajectoryBehaviour : MonoBehaviour, IFire
{
    [SerializeField] private Rigidbody shellPrefab;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private float launchForce = 20f;
    [SerializeField] private Transform turret;
    [SerializeField] private float turnSpeed = 2f;
    [SerializeField] private bool isLowAngle = true;
    [SerializeField] private float targetPrecision = 10f;

    private Transform target;
    private bool canShoot = true;

    private void Awake()
    {
        target = FindObjectOfType<PlayerStateController>().transform;
    }

    private void Update()
    {
        // LookAtTargetBehaviour
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);

        float? angle = RotateTurret();
        if (angle != null && Vector3.Angle(direction, transform.forward) < targetPrecision)
        {
            Fire();
        }
    }

    // ShootBehaviour
    public void Fire()
    {
        if (canShoot)
        {
            Rigidbody shellInstance = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation);
            shellInstance.velocity = launchForce * turret.forward;
            canShoot = false;
            Invoke(nameof(CanShootAgain), 0.5f);
        }
    }

    private float? CalculateAngle(bool low)
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

    private float? RotateTurret()
    {
        float? angle = CalculateAngle(isLowAngle);

        if (angle != null)
        {
            turret.localEulerAngles = new Vector3(360f - (float)angle, 0f, 0f);
        }

        return angle;
    }

    private void CanShootAgain()
    {
        canShoot = true;
    }
}