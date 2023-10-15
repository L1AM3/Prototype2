using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public HealthBar healthBar;

    public int Health = 5;

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
            healthBar.SetHealth(Health);
            Debug.Log(Health);
        }

        if (Health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
