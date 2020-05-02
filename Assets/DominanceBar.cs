using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DominanceBar : MonoBehaviour
{
    public Slider slider; //reference to shkala that we need to change

    public void SetMaxDominance(int dominance) //sets max dominance on the slider to the one we need 
    {
        slider.maxValue = dominance;
        slider.value = dominance / 2; //sets the slider at half the max dominance
    }
    public void SetDominance(int dominance) //sets the slider to represent the current dominance. 
    {
        slider.value = dominance;
    }
}
  // basically you need to get the reference to this script and set DominanceBar.SetDominance(here you put whatever value name you had in your script)