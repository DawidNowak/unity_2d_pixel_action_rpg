using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public Text healthText;

    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        slider.value = value;

        healthText.text = $"{value}/{value}";
    }
    public void SetValue(int value)
    {
        slider.value = value;
        healthText.text = $"{value}/{slider.maxValue}";
    }
}
