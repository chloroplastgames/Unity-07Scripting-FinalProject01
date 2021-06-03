﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TranslateBehaviour : MonoBehaviour, ITranslate
{
    [SerializeField] private float speed = 12f;

    private Rigidbody myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void Translate(float sense)
    {
        Vector3 movement = sense * speed * Time.deltaTime * transform.forward;
        myRigidbody.MovePosition(myRigidbody.position + movement);
    }
}