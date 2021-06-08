using System.Collections.Generic;

public class Player1CharacterSelectionBehaviour : PlayerCharacterSelectionBehaviourBase, ISubject<Player1CharacterSelectionEventArgs>
{
    private readonly List<IObserver<Player1CharacterSelectionEventArgs>> observers = new List<IObserver<Player1CharacterSelectionEventArgs>>();

    public void Add(IObserver<Player1CharacterSelectionEventArgs> observer)
    {
        if (observers.Contains(observer)) return;

        observers.Add(observer);
    }

    public void Remove(IObserver<Player1CharacterSelectionEventArgs> observer)
    {
        if (!observers.Contains(observer)) return;

        observers.Remove(observer);
    }

    public void Notify()
    {
        IObserver<Player1CharacterSelectionEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<Player1CharacterSelectionEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new Player1CharacterSelectionEventArgs(colorSelected));
        }
    }

    protected override void SaveSelection()
    {
        Notify();
    }
}