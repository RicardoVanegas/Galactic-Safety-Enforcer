using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lost : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LostGame()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0f;
        
    }
    public void restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
