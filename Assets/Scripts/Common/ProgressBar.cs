using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float target = 0f;

    public Slider slider;
    public Text healthText;

    private float FillSpeed => (slider.maxValue - slider.minValue) / 1f;
    private float Epsilon => (slider.maxValue - slider.minValue) / 1000f;

    public void SetMaxValue(int value, bool currentIsMax = true)
    {
        slider.maxValue = value;
        slider.value = currentIsMax ? value : 0f;
        target = slider.value;

        healthText.text = $"{slider.value}/{slider.maxValue}";
    }

    public void SetMinValue(int value)
    {
        slider.minValue = value;
    }

    public void SetValue(int value)
    {
        if (value < slider.minValue)
        {
            value = Mathf.RoundToInt(slider.minValue);
        }

        target = value;
        healthText.text = $"{value}/{slider.maxValue}";
    }

    void Update()
    {
        if (Mathf.Abs(slider.value - target) > Epsilon)
        {
            if (slider.value > target)
            {
                slider.value -= FillSpeed * Time.deltaTime;
            }
            else if (slider.value < target)
            {
                slider.value += FillSpeed * Time.deltaTime;
            }
        }
    }
}
