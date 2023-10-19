using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    //public reference to script
    public PauseMenu Pause;

    public void Starting()
    {
        //When pressed game will load
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        //When pressed main menu will load with normal time scale
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    public void Quiting()
    {
        //When pressed application will close
        Application.Quit();
    }

    public void Resume()
    {
        //When pressed unpause function will activate
        Pause.Unpause();
    }
}
