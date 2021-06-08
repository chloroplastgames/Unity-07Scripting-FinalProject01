using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTank : MonoBehaviour, IObserver<SelectedTank>
{
    private IEnumerator _routine;

    private RectTransform _myRectTransform;

    [SerializeField] private Image _tankView;

    [SerializeField] private int _playerId;

    private void Awake()
    {
        _routine = Select(0);

        _myRectTransform = transform as RectTransform;
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
        if (mensage.Action == TypeAction.SELECT && mensage.Player == _playerId)
        {
            if (_routine == null)
            {
                _routine = Select(mensage.Selected);

                StartCoroutine(_routine);
            }
            else
            {
                StopCoroutine(_routine);

                _routine = Select(mensage.Selected);

                StartCoroutine(_routine);
            }
        }
    }

    private IEnumerator Select(int selected)
    {
        float timeElapsed = 0;

        Quaternion originalRotation = _myRectTransform.rotation;

        Quaternion finalRotatio = Quaternion.Euler(0, 90, 0);

        while (true)
        {
            timeElapsed += Time.deltaTime;

            Quaternion newRotatio = Quaternion.Lerp(originalRotation, finalRotatio, timeElapsed / 0.5f);

            _myRectTransform.rotation = newRotatio;

            if (_myRectTransform.rotation == finalRotatio)
            {
                break;
            }
            yield return null;
        }
        _tankView.sprite = SelectionController.Instance.Data.TankSprite[selected];

        finalRotatio = Quaternion.Euler(0, 0, 0);

        originalRotation = _myRectTransform.rotation;

        timeElapsed = 0;

        while (true)
        {
            timeElapsed += Time.deltaTime;

            Quaternion newRotatio = Quaternion.Lerp(originalRotation, finalRotatio, timeElapsed / 0.5f);

            _myRectTransform.rotation = newRotatio;

            if (_myRectTransform.rotation == finalRotatio)
            {
                break;
            }
            yield return null;
        }
        _routine = null;
    }

    public void SetID(int id)
    {
        _playerId = id;
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (_playerId == 0)
        {
            GetComponent<Image>().color = new Color32(255,0,0,200); 
        }
        else if (_playerId == 1)
        {
            GetComponent<Image>().color = new Color32(0, 255, 0, 200);
        }
        else if (_playerId == 2)
        {
            GetComponent<Image>().color = new Color32(0, 0, 255, 200);
        }
        else if (_playerId == 3)
        {
            GetComponent<Image>().color = new Color32(0, 255, 255, 200);
        }
    }
}
