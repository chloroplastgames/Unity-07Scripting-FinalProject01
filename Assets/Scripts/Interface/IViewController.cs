using UnityEngine.InputSystem;

public interface IViewController: ISubject<SelectedTank>
{
    void Next(InputAction.CallbackContext ctx);

    void Previus(InputAction.CallbackContext ctx);

    void Confirm(InputAction.CallbackContext ctx);

    void Back(InputAction.CallbackContext ctx);

    void Desative();
}
