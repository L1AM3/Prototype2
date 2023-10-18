using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PausingMenu;
    // Start is called before the first frame update
    void Start()
    {
        PausingMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausingMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
      
    }

    public void Unpause()
    {
        PausingMenu.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
