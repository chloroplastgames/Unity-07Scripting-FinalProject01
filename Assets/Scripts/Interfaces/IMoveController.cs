public interface IMoveController
{
    void Move(IInput input);

    void CanMove(bool status);
}