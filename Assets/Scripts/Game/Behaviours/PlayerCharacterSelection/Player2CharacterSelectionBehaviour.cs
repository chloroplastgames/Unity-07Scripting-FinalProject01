public class Player2CharacterSelectionBehaviour : PlayerCharacterSelectionBehaviourBase
{
    protected override void SaveSelection()
    {
        GameManager.Instance.SetPlayer2Color(colorSelected);
    }
}