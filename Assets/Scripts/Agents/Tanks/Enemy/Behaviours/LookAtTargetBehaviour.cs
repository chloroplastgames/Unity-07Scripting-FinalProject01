﻿using UnityEngine;

/// <summary>
/// Behaviour to rotate the agent to look at target
/// </summary>

public class LookAtTargetBehaviour : MonoBehaviour, ILookAtTarget
{
    // TODO: move to config
    [SerializeField] private float speed = 3f;

    public Vector3 LookAtTarget(Transform target)
    {
        Vector3 targetDirectionNormalized = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(targetDirectionNormalized.x, 0, targetDirectionNormalized.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, speed * Time.deltaTime);

        return targetDirectionNormalized;
    }
}