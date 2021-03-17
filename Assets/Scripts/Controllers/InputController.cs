using UnityEngine;

public class InputController : MonoBehaviour
{
    private IPlayerInput _inputPlayerOne;

    private IPlayerInput _inputPlayerTwo;

    private BaseTank _playerOne;

    private void Awake()
    {
        _inputPlayerOne = PlayerDataFactory.GetInputOne();

        _inputPlayerTwo = PlayerDataFactory.GetInputTwo();

        _playerOne = GameManager.Instance.GetPlayerTransform().GetComponent<BaseTank>();
    }
    private void Update()
    {
        _playerOne.Move(_inputPlayerOne);
    }
}
