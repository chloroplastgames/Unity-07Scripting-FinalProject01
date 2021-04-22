using UnityEngine;

public class HealthTest : MonoBehaviour
{
    private IDamageable damager;

    private void Awake()
    {
        damager = GetComponent<IDamageable>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            damager.TakeDamage(10);
        }
    }
}