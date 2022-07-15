using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;

public class MainMenu : MonoBehaviour
{
    
    public void Start()
    {
       
    }

    public void startButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
        
    }
    public void quitGame()
    {
        Debug.Log("Quit");
        
        Application.Quit();
    }

    
}
