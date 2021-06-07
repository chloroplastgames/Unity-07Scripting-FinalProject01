using UnityEngine;
using UnityEngine.UI;

public class HoldShootController : MonoBehaviour, IShoot, IObserver<StartRoundEventArgs>
{
    [SerializeField] private PlayerControlData playerControl;
    [SerializeField] private Rigidbody shellPrefab;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private Slider aimSlider;
    [SerializeField] private AudioSource shootingAudio;
    [SerializeField] private AudioClip chargingClip;
    [SerializeField] private AudioClip fireClip;
    [SerializeField] private float minLaunchForce = 15f;
    [SerializeField] private float maxLaunchForce = 30f;
    [SerializeField] private float maxChargeTime = 0.75f;
    [SerializeField] private int minShellDamage = 1;
    [SerializeField] private int maxShellDamage = 3;

    private float currentLaunchForce;
    private int currentShellDamage;
    private float chargeSpeed;
    private bool fired;
    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        aimSlider.minValue = minLaunchForce;
        aimSlider.maxValue = maxLaunchForce;

        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;

        ResetSlider();
    }

    private void OnEnable()
    {
        gameController.StartRoundSubject.Add(this);
    }

    private void OnDisable()
    {
        gameController.StartRoundSubject.Remove(this);
    }

    public void OnNotify(StartRoundEventArgs parameter)
    {
        ResetSlider();
    }

    public void Shoot()
    {
        aimSlider.value = minLaunchForce;

        if (currentLaunchForce >= maxLaunchForce && !fired)
        {
            currentLaunchForce = maxLaunchForce;
            currentShellDamage = maxShellDamage;
            Fire();
        }
        else if (Input.GetKeyDown(playerControl.Shoot))
        {
            fired = false;
            currentLaunchForce = minLaunchForce;
            currentShellDamage = minShellDamage;

            shootingAudio.clip = chargingClip;
            shootingAudio.Play();
        }
        else if (Input.GetKey(playerControl.Shoot) && !fired)
        {
            currentLaunchForce += chargeSpeed * Time.deltaTime;
            currentShellDamage += Mathf.FloorToInt(chargeSpeed * Time.deltaTime);

            aimSlider.value = currentLaunchForce;
        }
        else if (Input.GetKeyUp(playerControl.Shoot) && !fired)
        {
            Fire();
        }
    }

    private void Fire()
    {
        fired = true;

        Rigidbody shellInstance = Instantiate(shellPrefab, fireTransform.position, fireTransform.rotation);

        shellInstance.velocity = currentLaunchForce * fireTransform.forward;
        shellInstance.GetComponent<IDealDamage>().Damage = currentShellDamage;

        shootingAudio.clip = fireClip;
        shootingAudio.Play();

        currentLaunchForce = minLaunchForce;
        currentShellDamage = minShellDamage;
    }

    private void ResetSlider()
    {
        currentLaunchForce = minLaunchForce;
        currentShellDamage = minShellDamage;
        aimSlider.value = minLaunchForce;
    }
}