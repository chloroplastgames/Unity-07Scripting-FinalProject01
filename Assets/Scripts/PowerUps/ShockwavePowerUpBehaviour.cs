using UnityEngine;

public class ShockwavePowerUpBehaviour : MonoBehaviour, IPowerUp, IObserver<EndRoundEventArgs>
{
    public string PowerUpName => powerUpName;

    [SerializeField] private string powerUpName = "shockwave";
    [SerializeField] private GameObject shockwaveParent;
    [SerializeField] private Animator shockwaveAnimator;

    private GameController gameController;

    private Coroutine shockwaveRoutine;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        gameController.EndRoundSubject.Add(this);
    }

    private void OnDisable()
    {
        gameController.EndRoundSubject.Remove(this);
    }

    public void Consume()
    {
        if (shockwaveRoutine != null) return;

        shockwaveParent.SetActive(true);

        shockwaveRoutine =
            CoroutinesHelperSingleton.Instance.WaitForSeconds(shockwaveAnimator.GetCurrentAnimatorStateInfo(0).length, () => ResetShockwave());
    }

    public void OnNotify(EndRoundEventArgs parameter)
    {
        if (shockwaveRoutine != null)
        {
            CoroutinesHelperSingleton.Instance.StopCoroutine(shockwaveRoutine);
        }

        ResetShockwave();
    }

    private void ResetShockwave()
    {
        shockwaveParent.SetActive(false);

        shockwaveRoutine = null;
    }
}