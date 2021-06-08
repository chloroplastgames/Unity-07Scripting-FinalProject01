using UnityEngine;
using UnityEngine.UI;

public class LeftBackgroundHUDBehaviour : MonoBehaviour
{
    [SerializeField] protected RawImage background;

    public void ChangeBackgroundColor(Color color)
    {
        background.color = color;
    }
}