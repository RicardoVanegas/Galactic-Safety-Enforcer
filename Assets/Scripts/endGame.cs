using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;
public class endGame : MonoBehaviour
{

    public GameObject endGamePanel;
    public Text scoreText;
    public Text seconds_text;
    public Text Higher_score_text;
    IDbConnection dbcon;
    // Start is called before the first frame update
    void Start()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/player_run_data"; //si no encuentra la base de datos en la direccion especificada, la crea
        dbcon = new SqliteConnection(connection);
        dbcon.Open();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LostGame(int score,int seconds,int high_score)
    {
        playerData data = SaveSystem.LoadPlayer();

        scoreText.text = score.ToString();
        Higher_score_text.text = high_score.ToString();
        seconds_text.text = seconds.ToString();
        endGamePanel.SetActive(true);

        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "INSERT INTO deaths (deathID, score,seconds,health,speed,damage,fire_rate,ammo,reload_speed) " +
            "VALUES ("+(GetRun()+1).ToString()+ "," + score +","+seconds+ ","+data.health_level+","+data.speed_level+","+data.damage_level+","+data.firingRate_level+","+data.ammo_level+","+data.reloadSpeed_level+")";
        cmnd.ExecuteNonQuery();
        dbcon.Close();
        
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

    public Int64 GetRun()
    {
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string query = "SELECT MAX(deathID) FROM deaths";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        if (reader.IsDBNull(0))
        {
            return 0;
        }
        else
        {
            return (Int64)reader.GetValue(0);
        }
        
    }
}