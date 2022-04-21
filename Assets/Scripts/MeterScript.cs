using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxBoost(float boost)
    {
        slider.maxValue = boost;
        slider.value = boost;

        fill.color = gradient.Evaluate (1f) ;
    }

    public void SetBoost(float boost)
    {
        slider.value = boost;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
