using UnityEngine;

public class RepairPowerUpBehaviour : MonoBehaviour, IPowerUp
{
    public string PowerUpName => powerUpName;

    [SerializeField] private string powerUpName = "repair";
    [SerializeField] private int healAmount = 3;

    private HealthBehaviour healthBehaviour;

    private void Awake()
    {
        healthBehaviour = GetComponent<HealthBehaviour>();
    }

    public void Consume()
    {
        healthBehaviour.Heal(healAmount);
    }
}