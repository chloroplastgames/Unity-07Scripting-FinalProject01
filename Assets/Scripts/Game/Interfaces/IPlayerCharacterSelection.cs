public interface IPlayerCharacterSelection
{
    bool Ready { get; }
    void PreviousSelection();
    void NextSelection();
    void SetSelection();
    void ResetSelection();
}