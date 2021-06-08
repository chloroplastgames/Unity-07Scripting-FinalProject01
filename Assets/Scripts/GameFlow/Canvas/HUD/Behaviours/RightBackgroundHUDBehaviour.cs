using UnityEngine;
using UnityEngine.UI;

public class RightBackgroundHUDBehaviour : MonoBehaviour
{
    [SerializeField] protected RawImage background;

    public void ChangeBackgroundColor(Color color)
    {
        background.color = color;
    }
}