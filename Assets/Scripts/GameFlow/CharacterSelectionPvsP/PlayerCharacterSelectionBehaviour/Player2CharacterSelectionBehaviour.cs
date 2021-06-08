using System.Collections.Generic;

public class Player2CharacterSelectionBehaviour : PlayerCharacterSelectionBehaviourBase, ISubject<Player2CharacterSelectionEventArgs>
{
    private readonly List<IObserver<Player2CharacterSelectionEventArgs>> observers = new List<IObserver<Player2CharacterSelectionEventArgs>>();

    public void Add(IObserver<Player2CharacterSelectionEventArgs> observer)
    {
        if (observers.Contains(observer)) return;

        observers.Add(observer);
    }

    public void Remove(IObserver<Player2CharacterSelectionEventArgs> observer)
    {
        if (!observers.Contains(observer)) return;

        observers.Remove(observer);
    }

    public void Notify()
    {
        IObserver<Player2CharacterSelectionEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<Player2CharacterSelectionEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new Player2CharacterSelectionEventArgs(colorSelected));
        }
    }

    protected override void SaveSelection()
    {
        Notify();
    }
}