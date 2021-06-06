public interface ICharacterSelectionPvsCPUEvents
{
    ISubject<Player1CharacterSelectionEventArgs> Player1CharacterSelectorSubject { get; }
    ISubject<CancelEventArgs> CancelCharacterSelectionSubject { get; }
}