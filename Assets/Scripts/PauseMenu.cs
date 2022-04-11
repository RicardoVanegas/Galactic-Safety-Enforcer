using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool game_paused=false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (game_paused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
        
    }
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        game_paused = false;
    }
    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        game_paused = true;

    }
    public void quit()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    } 
}
