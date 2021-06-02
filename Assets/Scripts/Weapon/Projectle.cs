using UnityEngine;

public sealed class Projectle : MonoBehaviour
{
    private float _time;
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 50;

        _time += Time.deltaTime;

        if(_time > 3)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Tank targetTank))
        {
            targetTank.TakeDamage(10);
        }
    }

    private void OnDisable()
    {
        _time = 0;
    }
}
