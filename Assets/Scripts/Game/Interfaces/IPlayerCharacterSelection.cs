public interface IPlayerCharacterSelection
{
    void PreviousSelection();
    void NextSelection();
    void SetSelection();
    bool IsReady();
    void ResetSelection();
}