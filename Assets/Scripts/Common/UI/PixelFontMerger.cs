using TMPro;
using UnityEngine;

public class PixelFontMerger : MonoBehaviour
{
    public GameObject textObject;
    public string text = "";
    public float fontSize = 12f;

    TextMeshProUGUI[] texts;

    void Awake()
    {
        texts = textObject.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var textMesh in texts)
        {
            textMesh.text = text;
            textMesh.fontSize = fontSize;
        }
    }

    public void SetText(string text)
    {
        foreach (var textMesh in texts)
        {
            textMesh.text = text;
        }
    }

    public void SetFontSize(float size)
    {
        foreach (var textMesh in texts)
        {
            textMesh.fontSize = size;
        }
    }
}
