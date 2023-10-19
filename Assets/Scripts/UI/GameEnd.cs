using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Will activate end condition if player collides with it
        if (other.tag == "Player")
        {
            //Loads end menu
            SceneManager.LoadScene("EndMenu");

            //Unlocks the cursor and makes it visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
