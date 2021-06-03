using UnityEngine;
using UnityEngine.UI;

public abstract class BackgroundHUDBehaviourBase : MonoBehaviour
{
    [SerializeField] protected RawImage background;

    protected abstract void OnEnable();
}