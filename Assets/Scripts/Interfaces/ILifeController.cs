public interface ILifeController
{
    void TakeDamage(float amount);

    void UpdateHealth();

    void Recovery(float amount);

    void Dead();
}