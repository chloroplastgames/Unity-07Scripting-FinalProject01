using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudController : MonoBehaviour
{
    #region Private variable
    private Canvas _canvas;
    [SerializeField] private TextMeshProUGUI _currentLife;
    [SerializeField] private Image _primaryAmmo;
    [SerializeField] private Image _secundaryAmmo;

    #endregion

    #region Public variable 
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }
    #endregion

    #region Own Methods
    public void SetCamera(Camera camera)
    {
        _canvas.worldCamera = camera;

        _canvas.planeDistance = 1;
    }

    public void UpdateLife(float amount)
    {
        _currentLife.text = amount.ToString("##");
    }

    public void UpdatePrimaryAmmo(float amount)
    {
        _primaryAmmo.fillAmount = amount;
    }

    public void UpdateSecundaryAmmo(float amount)
    {
        _secundaryAmmo.fillAmount = amount;
    }
    #endregion

}
