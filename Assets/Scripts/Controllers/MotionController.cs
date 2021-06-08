using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour, IMoveController
{
    #region Private variable

    private ITanks _tank;

    private Rigidbody _body; 

    private bool _canMove;

    private float _timeElapsed; 

    [SerializeField] private bool _isGrounded;
    #endregion

    #region Public variable

    #endregion

    #region Unity Methods
    private void Awake()
    {  
        _tank = GetComponent<TankManager>();

        _body = gameObject.AddComponent<Rigidbody>();

        _body.mass = 1200;

        _body.drag = 1;

        _body.angularDrag = 10; 
    }

    private void FixedUpdate()
    { 
        Move(_tank.Inputs);
    }

    private void Update()
    {
        _isGrounded = Physics.Raycast(transform.position,-transform.up, 2, ~LayerMask.GetMask("Tank"));

        if (!_isGrounded)
        {
            _timeElapsed += Time.deltaTime;

            if(_timeElapsed > 5)
            {
                _timeElapsed = 0;

                Teleport();
            }
        }
        else
        {
            _timeElapsed = 0;
        }
    }

    private void Teleport()
    {
        Vector3 pos = FieldController.Instance.GetRandomPosition();
        pos.z = pos.y;
        pos.y = -35;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.position = pos;
    }
    #endregion

    #region Own Methods
    public void CanMove(bool status)
    {
        _canMove = status;
    }

    public void Move(IInput input)
    {
        if (_canMove == false) return; 

        _body.AddRelativeForce(Vector3.forward * input.GetMotionDirection().y * _tank.Speed * 10, ForceMode.Acceleration);

        _body.AddRelativeTorque(Vector3.up * input.GetMotionDirection().x * _tank.Toquer / 2 * input.GetMotionDirection().y, ForceMode.VelocityChange);
    } 
    #endregion

}
