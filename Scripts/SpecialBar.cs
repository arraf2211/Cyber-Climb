using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialBar : MonoBehaviour
{
    public Slider SpecialSlider1; //calls in the slider object into here
    

    public void SetMaxSpecial(float special)
    {
        SpecialSlider1.maxValue = special; //so that slider starts with special value
        SpecialSlider1.value = special;

        
    }

    public void SetSpecial(float special) 
    {
        SpecialSlider1.value = special;

        
    }
}
