using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class endGame : MonoBehaviour
{

    public GameObject endGamePanel;
    public Text scoreText;
    public Text seconds_text;
    public Text Higher_score_text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LostGame(int score,int seconds,int high_score)
    {
        
        scoreText.text = score.ToString();
        Higher_score_text.text = high_score.ToString();
        seconds_text.text = seconds.ToString();
        endGamePanel.SetActive(true);
        Time.timeScale = 0f;

    }
    public void restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void menu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
    public void quit()
    {
        Application.Quit();
    }
}