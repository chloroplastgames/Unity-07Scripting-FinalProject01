public class Player1CharacterSelectionBehaviour : PlayerCharacterSelectionBehaviourBase
{
    protected override void SaveSelection()
    {
        GameManager.Instance.SetPlayer1Color(colorSelected);
    }
}