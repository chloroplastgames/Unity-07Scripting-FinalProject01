using UnityEngine;

public class UtilityFunctionsHelper : MonoBehaviour
{
    public static void ColorGameObject(GameObject gameObject, Color color)
    {
        MeshRenderer[] meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material.color = color;
        }
    }
}