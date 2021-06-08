using UnityEngine;

/// <summary>
/// Utilities
/// </summary>

public class UtilityFunctionsHelper : MonoBehaviour
{
    /// <summary>
    /// Colors a game object
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="color"></param>
    public static void ColorGameObject(GameObject gameObject, Color color)
    {
        MeshRenderer[] meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material.color = color;
        }
    }
}