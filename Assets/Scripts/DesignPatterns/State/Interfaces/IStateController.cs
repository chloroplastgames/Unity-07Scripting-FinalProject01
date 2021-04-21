public interface IStateController
{
    void SwitchState<T>() where T : IState;
}