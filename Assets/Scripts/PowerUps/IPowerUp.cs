/// <summary>
/// Interface that all power ups implement. Polymorphism
/// </summary>

public interface IPowerUp
{
    string PowerUpName { get; }
    void Consume();
}