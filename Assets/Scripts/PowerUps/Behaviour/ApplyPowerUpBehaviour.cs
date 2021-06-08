using UnityEngine;

/// <summary>
/// Behaviour to apply power up to powerupable target
/// </summary>

public class ApplyPowerUpBehaviour : MonoBehaviour, IApplyPowerUp
{
    [SerializeField] private int id;

    public void ApplyPowerUp(IPowerUpable target)
    {
        target.ApplyPowerUp(id);
    }
}