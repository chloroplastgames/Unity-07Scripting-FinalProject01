using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotateBehaviour : MonoBehaviour, IRotate
{
    [SerializeField] private float speed = 180f;

    private Rigidbody myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Rotate(float sense)
    {
        float rotation = sense * speed * Time.deltaTime;
        Quaternion yRotation = Quaternion.Euler(0f, rotation, 0f);
        myRigidbody.MoveRotation(myRigidbody.rotation * yRotation);
    }
}