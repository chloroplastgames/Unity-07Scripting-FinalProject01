using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ITranslate translator;
    private IRotate rotator;
    private IFire shooter;
    private float translationSense;
    private float rotationSense;

    private void Awake()
    {
        translator = GetComponent<ITranslate>();
        rotator = GetComponent<IRotate>();
        shooter = GetComponent<IFire>();
    }

    private void Update()
    {
        translationSense = Input.GetAxis("Vertical1");
        rotationSense = Input.GetAxis("Horizontal1");

        if (Input.GetKeyDown(KeyCode.B))
        {
            shooter.Fire();
        }
    }

    private void FixedUpdate()
    {
        translator.Translate(translationSense);
        rotator.Rotate(rotationSense);
    }
}