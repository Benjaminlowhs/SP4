using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryHealthBar : MonoBehaviour
{

    public Slider slider;
    public Image fill;
    // Start is called before the first frame update
    public void SetMaxBatteryHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetBatteryHealth(float health)
    {
        slider.value = health;
    }
}
