using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public HealthBar healthBar;
    public HealthBarAnimation healthBarAnimation;

    public int Health = 15;

    private void Start()
    {
        healthBar.SetMaxHealth(Health);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Health--;
            healthBarAnimation.PenguinHealthBarAnimation(true);
            healthBar.SetHealth(Health);
            Invoke("Delay", 2);
            //Debug.Log(Health);
        }

        if (Health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Delay()
    {
        healthBarAnimation.PenguinHealthBarAnimation(false);
    }
}
