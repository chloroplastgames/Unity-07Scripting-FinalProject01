using System.Collections; 
using UnityEngine;
using TMPro;

public class GameplayerController : MonoBehaviour
{
    #region Private variable
    [SerializeField] private Canvas _canvasWarn;
    [SerializeField] private TextMeshProUGUI _cdText;
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    private void Start()
    {
        StartCoroutine(CountDown());
    }
    #endregion

    #region Own Methods

    private IEnumerator CountDown()
    {
        float time = 5;
        while (true)
        {
            time -= Time.deltaTime;
            _cdText.text = time.ToString("#");
            if (time <= 0)
            {
                break;
            }
            yield return null;
        }
        Tank[] allTanks = FindObjectsOfType<Tank>();

        foreach (var item in allTanks)
        {
            item.SetupMotion(true);
            item._eventDead += CheckTanks;
        }
        _canvasWarn.gameObject.SetActive(false);

    }
    public void CheckTanks()
    {
        Tank[] allTanks = FindObjectsOfType<Tank>();

        int count = 0;

        foreach (var item in allTanks)
        {
            if (item.IsDead)
            {
                count++; 
            }
        }
        if(count == 1)
        { 
            FindObjectOfType<LoadController>().NewScene(0);
        }

    }
    #endregion
}
