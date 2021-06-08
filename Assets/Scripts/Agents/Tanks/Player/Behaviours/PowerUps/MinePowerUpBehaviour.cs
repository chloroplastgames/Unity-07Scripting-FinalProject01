using UnityEngine;

public class MinePowerUpBehaviour : MonoBehaviour, IPowerUp
{
    public string PowerUpName => powerUpName;

    [SerializeField] private string powerUpName = "mine";
    [SerializeField] private GameObject minePrefab;

    public void Consume()
    {
        Instantiate(minePrefab, transform.position, transform.rotation);
    }
}