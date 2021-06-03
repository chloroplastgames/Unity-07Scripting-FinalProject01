public class Player2CharacterSelectionBehaviour : PlayerCharacterSelectionBehaviourBase
{
    protected override void SaveSelection()
    {
        GameManagerSingleton.Instance.SetTank2Color(colorSelected);
    }
}