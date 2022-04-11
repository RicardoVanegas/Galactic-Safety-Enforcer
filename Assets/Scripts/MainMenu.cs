using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;

public class MainMenu : MonoBehaviour
{
    IDbConnection dbcon;
    public void Start()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/player_run_data"; //si no encuentra la base de datos en la direccion especificada, la crea
        dbcon = new SqliteConnection(connection);
        dbcon.Open();
        CreateT();
    }

    public void startButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
        dbcon.Close();
    }
    public void quitGame()
    {
        Debug.Log("Quit");
        dbcon.Close();
        Application.Quit();
    }

    void CreateT()
    {
        IDbCommand dbcmd;

        dbcmd = dbcon.CreateCommand();
        string q_createTable =
          "CREATE TABLE IF NOT EXISTS deaths (deathID INTEGER PRIMARY KEY, score INTEGER, seconds INTEGER, health integer, speed integer, damage integer, fire_rate integer, ammo integer, reload_speed integer)";

        dbcmd.CommandText = q_createTable;
        dbcmd.ExecuteReader();
    }
}
