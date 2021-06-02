public class Player1CharacterSelectionBehaviour : PlayerCharacterSelectionBehaviourBase
{
    protected override void SaveSelection()
    {
        GameManagerSingleton.Instance.SetTank1Color(colorSelected);
    }
}