public interface IState
{
    void UpdateLogic();
    void Enter();
    void Exit();
    void UpdatePhysic();
}
