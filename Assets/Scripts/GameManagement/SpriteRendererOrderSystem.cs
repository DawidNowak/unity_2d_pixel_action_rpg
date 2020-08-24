using UnityEngine;

public class SpriteRendererOrderSystem : MonoBehaviour
{
    void Update()
    {
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();

        foreach (var renderer in renderers)
        {
            renderer.sortingOrder = (int)(renderer.transform.position.y * -10);
        }
    }
}
