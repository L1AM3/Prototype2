using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Healthslider;
    public Gradient Healthgradient;
    public Image HealthImage;

    private void Start()
    {
        Healthslider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int playerhealth)
    {
        Healthslider.maxValue = playerhealth;
        HealthImage.color = Healthgradient.Evaluate(1.0f);
    }

    public void SetHealth(int playerhealth)
    {
        Healthslider.value = playerhealth;
        HealthImage.color = Healthgradient.Evaluate(Healthslider.normalizedValue);
    }
}
