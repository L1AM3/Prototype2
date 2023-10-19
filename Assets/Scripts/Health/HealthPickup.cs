using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    //public references for scripts
    public HealthSystem Health;
    public HealthBarAnimation HealthBarAnim;
    public AudioManager AudioManager;

    //int for health incriment
    private int healthincriment = 5;

    private void OnTriggerEnter(Collider other)
    {
        //If the players health is 10 or less, the health incriment will be added to total health
        if (Health.Health <= 10)
        {
            //Plays audio clip when pickup is collected
            AudioManager.PlayClip();

            //Animates health bar to be visible
            HealthBarAnim.PenguinHealthBarAnimation(true);

            //Adds health incriment to player health
            Health.Health += healthincriment;

            //Sets health pick up to false 
            gameObject.SetActive(false);

            //Reverts health bar back to invisible
            Invoke("Delay", 1);
        }

        //If the players health is more than 10 and less than 15, the health will be set to max health
        if (Health.Health >= 10 && Health.Health <= 15)
        {
            //Plays audio clip when pickup is collected
            AudioManager.PlayClip();

            //Animates health bar to be visible
            HealthBarAnim.PenguinHealthBarAnimation(true);

            //Sets health to full
            Health.Health = 15;

            //Sets health pick up to false
            gameObject.SetActive(false);

            //Reverts health bar back to invisible
            Invoke("Delay", 1);
        }
    }

    public void Delay()
    {
        //Reverts health bar back to invisible
        HealthBarAnim.PenguinHealthBarAnimation(false);
    }
}
