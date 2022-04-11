using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Scores : MonoBehaviour
{
    public GameObject cellPrefab;

    IDbConnection dbcon;
    // Start is called before the first frame update
    void Start()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/player_run_data"; //si no encuentra la base de datos en la direccion especificada, la crea
        dbcon = new SqliteConnection(connection);
        dbcon.Open();
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string size = "select count(*) from deaths";
        cmnd_read.CommandText = size;
        reader = cmnd_read.ExecuteReader();
        Int64 rows = (Int64)reader.GetValue(0);
        dbcon.Close();

        dbcon.Open();
        cmnd_read = dbcon.CreateCommand();
        string query = "SELECT * FROM deaths";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        for(int i = 0; i < rows; i++)
        {
            reader.Read();
            GameObject obj = Instantiate(cellPrefab);
            obj.transform.SetParent(this.gameObject.transform,false);
            for(int j = 0; j < 9; j++)
            {
                obj.transform.GetChild(j).GetComponent<Text>().text = reader.GetValue(j).ToString();
            }
        }
        dbcon.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
