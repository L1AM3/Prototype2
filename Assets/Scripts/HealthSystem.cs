using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int Health = 5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Health--;
            Debug.Log(Health);
        }

        if (Health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
