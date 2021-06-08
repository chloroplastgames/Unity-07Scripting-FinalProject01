using UnityEngine;

/// <summary>
/// Controller to apply this power up to the target when triggered
/// </summary>

public class PowerUpController : MonoBehaviour
{
    private IApplyPowerUp powerUpApplier;
    private IKillable killer;

    private void Awake()
    {
        powerUpApplier = GetComponent<IApplyPowerUp>();
        killer = GetComponent<IKillable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        IPowerUpable target = other.GetComponent<IPowerUpable>();

        if (target != null)
        {
            powerUpApplier.ApplyPowerUp(target);
        }

        killer.Kill();
    }
}