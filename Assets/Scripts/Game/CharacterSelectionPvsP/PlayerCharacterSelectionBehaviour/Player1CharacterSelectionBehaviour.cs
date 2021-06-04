using System.Collections.Generic;

public class Player1CharacterSelectionBehaviour : PlayerCharacterSelectionBehaviourBase, ISubject<Player1CharacterSelectionArgs>
{
    private readonly List<IObserver<Player1CharacterSelectionArgs>> observers = new List<IObserver<Player1CharacterSelectionArgs>>();

    public void Add(IObserver<Player1CharacterSelectionArgs> observer)
    {
        if (observers.Contains(observer)) return;

        observers.Add(observer);
    }

    public void Remove(IObserver<Player1CharacterSelectionArgs> observer)
    {
        if (!observers.Contains(observer)) return;

        observers.Remove(observer);
    }

    public void Notify()
    {
        IObserver<Player1CharacterSelectionArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<Player1CharacterSelectionArgs> observer in observersPhoto)
        {
            observer.OnNotify(new Player1CharacterSelectionArgs(colorSelected));
        }
    }

    protected override void SaveSelection()
    {
        Notify();
    }
}