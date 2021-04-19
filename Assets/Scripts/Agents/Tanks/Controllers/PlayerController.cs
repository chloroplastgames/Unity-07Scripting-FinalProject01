using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ITranslate translator;
    private IRotate rotator;
    private float translationSense;
    private float rotationSense;


    private void Awake()
    {
        translator = GetComponent<ITranslate>();
        rotator = GetComponent<IRotate>();
    }

    private void Update()
    {
        translationSense = Input.GetAxis("Vertical1");
        rotationSense = Input.GetAxis("Horizontal1");
    }

    private void FixedUpdate()
    {
        translator.Translate(translationSense);
        rotator.Rotate(rotationSense);
    }
}