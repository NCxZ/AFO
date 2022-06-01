using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject pause;
    public GameObject resume;
    public GameHandler gameobj;
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PauseGame()
    {
        if (Time.timeScale != 0)
        {
            gameobj.paused = true;
            Time.timeScale = 0;
            pause.active = false;
        }
        else
        {
            gameobj.paused = false;
            Time.timeScale = 1;
            pause.active = true;
        }
    }
}
