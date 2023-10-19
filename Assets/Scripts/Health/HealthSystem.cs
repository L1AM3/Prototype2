using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    //public references to other scripts
    public HealthBar HealthBar;
    public HealthBarAnimation HealthBarAnimation;

    //int for player health
    public int Health = 15;

    private void Start()
    {
        //Sets healthbar max to max health
        HealthBar.SetMaxHealth(Health);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player gets hit by enemy sawblade then the player will take damage 
        if (other.tag == "Enemy")
        {
            //Takes one health away from player health
            Health--;

            //Animates health bar to be visible
            HealthBarAnimation.PenguinHealthBarAnimation(true);

            //Sets health bar to current health
            HealthBar.SetHealth(Health);

            //Reverts health bar back to invisible
            Invoke("Delay", 1);
        }

        if (Health <= 0)
        {
            //If health is zero reload the scene
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Delay()
    {
        //Reverts health bar back to invisible
        HealthBarAnimation.PenguinHealthBarAnimation(false);
    }
}
