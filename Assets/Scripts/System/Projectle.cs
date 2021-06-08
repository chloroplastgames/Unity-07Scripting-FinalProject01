using UnityEngine;

public sealed class Projectle : MonoBehaviour, IProjectle
{
    private float _modDamage;

    private float _elapsedTime;

    [SerializeField] private float _damage;

    [SerializeField] private float _speed;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        transform.position += transform.forward * _speed * Time.deltaTime;

        if(_elapsedTime > 2)
        {
            Disable();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ILifeController tank))
        {
            tank.TakeDamage(_damage + _modDamage);

            Disable();
        }
    }
    public void Disable()
    {
        gameObject.SetActive(false);

        _elapsedTime = 0;
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void SetupDamage(float damage)
    {
        _modDamage += damage;
    }

    public void SetupDirection(Vector3 direction)
    {
        transform.forward = direction;
    }
}
