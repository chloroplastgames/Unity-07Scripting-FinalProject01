using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HudController : MonoBehaviour, IObserver<float>
{
    [SerializeField] private TextMeshProUGUI _life;

    [SerializeField] private Image _ammunitionPrimary;

    [SerializeField] private Image _cdPrimary;

    [SerializeField] private Image _ammunitionSecundary;

    [SerializeField] private Image _cdSecundary;

    public int PlayerID { get; private set; }

    public void Notify(float mensage)
    {
        _life.text = mensage.ToString();
    }

    public void UpdateAmmunitionPrimary(float amount)
    {
        _ammunitionPrimary.fillAmount = amount;
    }
    public void UpdateCdPrimary(float amount)
    {
        _cdPrimary.fillAmount = amount;
    }

    public void UpdateAmmunitionSecundary(float amount)
    {
        _ammunitionSecundary.fillAmount = amount;
    }

    public void UpdateCdSecundary(float amount)
    {
        _cdSecundary.fillAmount = amount;
    }

    public void SetupID(int id)
    {
        PlayerID = id;
    }
}