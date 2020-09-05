using TMPro;
using UnityEngine;

public class PixelFontMerger : MonoBehaviour
{
    public GameObject textObject;
    public string text = "";
    public float fontSize = 12f;

    void Awake()
    {
        var textMeshPros = textObject.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var textMesh in textMeshPros)
        {
            textMesh.text = text;
            textMesh.fontSize = fontSize;
        }
    }
}
