using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public sealed class ViewTank : MonoBehaviour, IObserver<SelectedTank>
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
    public void Notify(SelectedTank mensage)
    {
        if(mensage.Action == TypeAction.SELECT && mensage.Player == _playerId)
        {
            if(_routine == null)
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
        _tankView.sprite = FindObjectOfType<SelectionController>().DataSelection.TanksSprites[selected];
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
        if(_playerId == 0)
        {
            GetComponent<Image>().color = Color.red;
        }
        else if(_playerId == 1)
        {
            GetComponent<Image>().color = Color.green; 
        }
        else if (_playerId == 2)
        {
            GetComponent<Image>().color = Color.cyan;
        }
        else if (_playerId == 3)
        {
            GetComponent<Image>().color = Color.blue;
        }
    }
}
