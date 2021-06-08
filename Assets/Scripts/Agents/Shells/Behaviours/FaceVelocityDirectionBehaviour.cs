using UnityEngine;

/// <summary>
/// Behaviour to face the velocity of the rigidbody
/// </summary>

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