using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FaceVelocityDirectionBehaviour : MonoBehaviour, IFaceVelocityDirection
{
    private Rigidbody myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void FaceVelocityDirection()
    {
        transform.forward = myRigidbody.velocity;
    }
}