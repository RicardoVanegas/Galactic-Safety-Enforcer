using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class mainScreen : MonoBehaviour
{

    public GameObject menu_panel;
    public GameObject start_panel;


    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/playerData.txt";
        string path2 = Application.persistentDataPath + "/MothershipData.txt";
        if (File.Exists(path) && File.Exists(path2))
        {
            Invoke("changePanel", .75f);
        }
        else
        {
            SaveSystem.createPlayer();
            SaveSystem.createBase();
            Invoke("changePanel", .75f);
        }
    }
    public void changePanel()
    {
        start_panel.SetActive(false);
        menu_panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}