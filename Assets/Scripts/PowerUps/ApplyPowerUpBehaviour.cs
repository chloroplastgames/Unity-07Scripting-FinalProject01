using UnityEngine;

public class ApplyPowerUpBehaviour : MonoBehaviour, IApplyPowerUp
{
    [SerializeField] private int id;

    public void ApplyPowerUp(IPowerUpable target)
    {
        target.ApplyPowerUp(id);
    }
}