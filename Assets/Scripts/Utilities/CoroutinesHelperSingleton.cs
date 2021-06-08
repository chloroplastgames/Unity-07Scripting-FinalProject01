using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Singleton to handle coroutines in Monobehaviour and non-Monobehaviour scripts
/// </summary>

public class CoroutinesHelperSingleton : Singleton<CoroutinesHelperSingleton>
{
    /// <summary>
    /// Executes callback after time in seconds
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public Coroutine WaitForSeconds(float seconds, Action callback)
    {
        return StartCoroutine(WaitForSecondsRoutine(seconds, callback));
    }

    private IEnumerator WaitForSecondsRoutine(float seconds, Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback();
    }
}