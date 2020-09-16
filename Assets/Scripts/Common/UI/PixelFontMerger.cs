using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class PixelFontMerger : MonoBehaviour
{
    public GameObject textObject;
    public string text = "";
    public float fontSize = 12f;

    TextMeshProUGUI[] texts;

    public string stringValue
    {
        get
        {
            return texts.First().text;
        }
        set
        {
            foreach (var textMesh in texts)
            {
                textMesh.text = value;
            }
        }
    }

    public void SetText(string text)
    {
        if (texts == null)
        {
            Init();
        }
        foreach (var textMesh in texts)
        {
            textMesh.text = text;
        }
    }

    public void SetFontSize(float size)
    {
        if (texts == null)
        {
            Init();
        }
        foreach (var textMesh in texts)
        {
            textMesh.fontSize = size;
        }
    }

    private void Init()
    {
        texts = textObject.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var textMesh in texts)
        {
            textMesh.text = text;
            textMesh.fontSize = fontSize;
        }
    }
}
