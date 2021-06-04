public interface ICharacterSelectionPvsPEvents
{
    ISubject<Player1CharacterSelectionArgs> Player1CharacterSelectorSubject { get; }
    ISubject<Player2CharacterSelectionArgs> Player2CharacterSelectorSubject { get; }
}