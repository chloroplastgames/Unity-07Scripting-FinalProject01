using UnityEngine;
using UnityEngine.UI;

public sealed class TankSelector: MonoBehaviour, IObserver<SelectedTank>
{
    private Image[] _playes = new Image[4];
    [SerializeField] private int _id; 

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _playes[i] = transform.GetChild(i).GetComponent<Image>();
            _playes[i].enabled = false;
        }
    }
    private void OnEnable()
    {
        SelectionTank[] controllers = FindObjectsOfType<SelectionTank>();

        foreach (var controller in controllers)
        {
            controller.Register(this);
        }
    }

    private void OnDisable()
    {
        SelectionTank[] controllers = FindObjectsOfType<SelectionTank>();

        foreach (var controller in controllers)
        {
            controller.Remove(this);
        }
    }

    public void Notify(SelectedTank mensage)
    {
        if (mensage.Selected != _id) return;

        if (mensage.Action == TypeAction.SELECT)
        { 
            _playes[mensage.Player].enabled = true;
        }
        else
        {
            _playes[mensage.Player].enabled = false;
        }
    }
}
