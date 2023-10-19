using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public HealthSystem Health;
    public HealthBarAnimation HealthBarAnim;
    public AudioManager AudioManager;

    private int healthincriment = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (Health.Health <= 10)
        {
            AudioManager.PlayClip();
            HealthBarAnim.PenguinHealthBarAnimation(true);
            Health.Health += healthincriment;
            gameObject.SetActive(false);
            Invoke("Delay", 1);
            Debug.Log(Health.Health);
        }

        if (Health.Health >= 10 && Health.Health <= 15)
        {
            AudioManager.PlayClip();
            HealthBarAnim.PenguinHealthBarAnimation(true);
            Health.Health = 15;
            gameObject.SetActive(false);
            Invoke("Delay", 1);
            Debug.Log(Health.Health);
        }
    }

    public void Delay()
    {
        HealthBarAnim.PenguinHealthBarAnimation(false);
    }
}
