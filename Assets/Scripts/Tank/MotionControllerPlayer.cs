using UnityEngine;

public sealed class MotionControllerPlayer : IMotionController
{ 
    private Tank _tank;

    private float rotX;

    private Rigidbody _body; 

    public void SetupTank(Tank tank)
    {
        _tank = tank;
        _body = _tank.gameObject.AddComponent<Rigidbody>();
        _body.mass = 500;
        _body.centerOfMass = _tank.CenterOfMass;
    }

    public void Move(IInput input)
    {
        if (_tank == null) return;

        rotX += input.GetMotionDirection().x * _body.velocity.magnitude;

        _tank.transform.rotation = Quaternion.Euler(_tank.transform.rotation.eulerAngles.x, rotX, _tank.transform.eulerAngles.z);

        Vector3 finalVelocity = _tank.transform.forward * input.GetMotionDirection().y * _tank.Data.MotionSpeed;

        finalVelocity.y = _body.velocity.y;

        _body.velocity = finalVelocity;
    }
}
