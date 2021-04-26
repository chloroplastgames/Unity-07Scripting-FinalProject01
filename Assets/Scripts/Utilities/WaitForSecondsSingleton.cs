using System;
using System.Collections;
using UnityEngine;

public class WaitForSecondsSingleton : Singleton<WaitForSecondsSingleton>
{
    public void WaitForSeconds(float seconds, Action callback)
    {
        StartCoroutine(WaitForSecondsRoutine(seconds, callback));
    }

    private IEnumerator WaitForSecondsRoutine(float seconds, Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback();
    }
}