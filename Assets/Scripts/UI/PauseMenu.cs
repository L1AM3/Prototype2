using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //game object reference for pause menu
    [SerializeField] private GameObject pausingMenu;

    // Start is called before the first frame update
    void Start()
    {
        //default the pause menu to off
        pausingMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //When pressing escape the pause menu will activate
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Pulls up pause menu
            pausingMenu.SetActive(true);

            //Pauses time in the game
            Time.timeScale = 0;

            //Sets cursor to visible and unlocks them
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
      
    }

    //Called to unpause the pause menu
    public void Unpause()
    {
        //Gets rid of the pause menu from the player's display
        pausingMenu.SetActive(false);

        //Sets time scale back to normal
        Time.timeScale = 1.0f;

        //Locks the cursor and makes it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
