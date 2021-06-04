using System.Collections.Generic;

public class Player2CharacterSelectionBehaviour : PlayerCharacterSelectionBehaviourBase, ISubject<Player2CharacterSelectionArgs>
{
    private readonly List<IObserver<Player2CharacterSelectionArgs>> observers = new List<IObserver<Player2CharacterSelectionArgs>>();

    public void Add(IObserver<Player2CharacterSelectionArgs> observer)
    {
        if (observers.Contains(observer)) return;

        observers.Add(observer);
    }

    public void Remove(IObserver<Player2CharacterSelectionArgs> observer)
    {
        if (!observers.Contains(observer)) return;

        observers.Remove(observer);
    }

    public void Notify()
    {
        IObserver<Player2CharacterSelectionArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<Player2CharacterSelectionArgs> observer in observersPhoto)
        {
            observer.OnNotify(new Player2CharacterSelectionArgs(colorSelected));
        }
    }

    protected override void SaveSelection()
    {
        Notify();
    }
}