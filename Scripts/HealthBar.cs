using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthSlider1; //calls in the slider object into here

    public void SetMaxHealth(float health)
    {
        HealthSlider1.maxValue = health; //so that slider starts with max health 
        HealthSlider1.value = health;
    }

    public void SetHealth(float health) //so that the slider adjusts the healthbar to the health 
    {
        HealthSlider1.value = health;
    }
}
