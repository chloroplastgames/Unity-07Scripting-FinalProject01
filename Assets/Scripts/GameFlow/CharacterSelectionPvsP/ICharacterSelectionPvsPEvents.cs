public interface ICharacterSelectionPvsPEvents
{
    ISubject<Player1CharacterSelectionEventArgs> Player1CharacterSelectorSubject { get; }
    ISubject<Player2CharacterSelectionEventArgs> Player2CharacterSelectorSubject { get; }
    ISubject<CancelEventArgs> CancelCharacterSelectionSubject { get; }
}