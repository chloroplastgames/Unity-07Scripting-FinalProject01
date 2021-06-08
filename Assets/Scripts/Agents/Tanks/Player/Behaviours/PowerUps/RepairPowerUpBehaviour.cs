using UnityEngine;

public class RepairPowerUpBehaviour : MonoBehaviour, IPowerUp
{
    public string PowerUpName => powerUpName;

    [SerializeField] private string powerUpName = "repair";
    [SerializeField] private int healAmount = 3;

    private HealthController healthBehaviour;

    private void Awake()
    {
        healthBehaviour = GetComponent<HealthController>();
    }

    // Has access to agent health
    public void Consume()
    {
        healthBehaviour.Heal(healAmount);
    }
}