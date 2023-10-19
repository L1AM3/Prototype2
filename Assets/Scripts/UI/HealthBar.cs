using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //references for the health bar and its componets
    public Slider Healthslider;
    public Gradient Healthgradient;
    public Image HealthImage;

    private void Start()
    {
        //Gets health slider compent of the health bar
        Healthslider = GetComponent<Slider>();
    }

    //Sets the health bar to the max player health
    public void SetMaxHealth(int playerhealth)
    {
        //Sets health slider value at max to max health and changes gradient accordingly
        Healthslider.maxValue = playerhealth;
        HealthImage.color = Healthgradient.Evaluate(1.0f);
    }

    //Updates the health bar when the player takes damage
    public void SetHealth(int playerhealth)
    {
        //Sets health slider and gradient to updated player health
        Healthslider.value = playerhealth;
        HealthImage.color = Healthgradient.Evaluate(Healthslider.normalizedValue);
    }
}
