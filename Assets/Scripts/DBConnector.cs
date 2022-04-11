using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
public class DBConnector : MonoBehaviour
{
    void Start()
    {

        string connection = "URI=file:" + Application.persistentDataPath + "/My_Database"; //si no encuentra la base de datos en la direccion especificada, la crea
        //Debug.Log(connection);
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();
        //alguna de las fuinciones para trabajar la base de datos
        CreateT(dbcon);
        SelectT(dbcon);
        dbcon.Close();
    }


    void CreateT(IDbConnection dbcon)
    {
        IDbCommand dbcmd;
        IDataReader reader;

        dbcmd = dbcon.CreateCommand();
        string q_createTable =
          "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val INTEGER )";

        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
    }

    void InsertT(IDbConnection dbcon, string id ,string val)
    {
        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "INSERT INTO my_table (id, val) VALUES ("+id+","+ val+")";
        cmnd.ExecuteNonQuery();
    }

    void SelectT(IDbConnection dbcon)
    {
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string query = "SELECT * FROM my_table";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        while (reader.Read())
        {
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("val: " + reader[1].ToString());
        }
    }
}