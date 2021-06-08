using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayerController : MonoBehaviour,IObserver<Teams>
{
    #region Private variable
    private float _countDown = 5;
    private Dictionary<Teams, bool> _win = new Dictionary<Teams, bool>();
    [SerializeField] private GamePlayerData _data;
    [SerializeField] private Camera _worldCamera;
    [SerializeField] private TextMeshProUGUI _text;
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    private void Start()
    {
        StartCoroutine(CountDown());

        for (int i = 0; i < _data.NPlayer; i++)
        {
            _win.Add((Teams)i, true);
        }

        AudioController.Instance.PlayAudio(1);
    }
    #endregion

    #region Own Methods
    private IEnumerator CountDown()
    {
        while (true)
        {
            _countDown -= Time.deltaTime;
            _text.text = _countDown.ToString("##");
            if(_countDown <= 0)
            {
                _text.text = "";

                foreach (var item in FindObjectsOfType<MotionController>())
                {
                    item.CanMove(true);
                }
                yield break;
            }
            yield return null; 
        }
    }

    public void Notify(Teams mensage)
    {
        _win[mensage] = false;

        int count = 0;

        KeyValuePair<Teams, bool> victory = new KeyValuePair<Teams, bool>(Teams.TEAM_TREE, true);

        foreach (var item in _win)
        {
            if(item.Value == true)
            {
                victory = item;
                count++;
            }
        }
        if(count == 1)
        {
            StartCoroutine(Victory(victory));
        }else if(count == 0)
        {
            StartCoroutine(Victory(victory));
        }
    }

    private IEnumerator Victory(KeyValuePair<Teams, bool> victory)
    {
        foreach (var item in FindObjectsOfType<MotionController>())
        {
            item.CanMove(false);
        }
        _text.fontSize = 200;

        _text.text = $"Team {victory.Key} victory";

        yield return new WaitForSeconds(1.5f);

        FadeController.Instance.NewScene(0);
    }
    #endregion

}
