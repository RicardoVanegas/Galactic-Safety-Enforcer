using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemy_type1;
    public GameObject enemy_type2;
    public GameObject enemy_type3;
    public Transform [] spawn_spot = new Transform[3];
    private float enemy1_time = 5;
    private float enemy2_time = 7;
    private float enemy3_time = 10;
    
    // Start is called before the first frame update
    void Start()
    {

        Invoke("spawnEnemy",1f);
        Invoke("spawnEnemy2", 3f);
        Invoke("spawnEnemy3", 5f);
        StartCoroutine(spawn());
        StartCoroutine(spawn2());
        StartCoroutine(spawn3());
        StartCoroutine(reduceTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnEnemy()
    {
        int n = Random.Range(1, 4);
        if (n == 1)
        {
            GameObject enemy = Instantiate(enemy_type1) as GameObject;
            enemy.transform.position = spawn_spot[0].position;

        }
        if (n == 2)
        {
            GameObject enemy = Instantiate(enemy_type1) as GameObject;
            enemy.transform.position = spawn_spot[1].position;
        }
        if (n == 3)
        {
            GameObject enemy = Instantiate(enemy_type1) as GameObject;
            enemy.transform.position = spawn_spot[2].position;
        }
    }
    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemy1_time);
            spawnEnemy();
        }
       
        
    }

    public void spawnEnemy2()
    {
        int n = Random.Range(1, 4);
        if (n == 1)
        {
            GameObject enemy2 = Instantiate(enemy_type2) as GameObject;
            enemy2.transform.position = spawn_spot[0].position;

        }
        if (n == 2)
        {
            GameObject enemy2 = Instantiate(enemy_type2) as GameObject;
            enemy2.transform.position = spawn_spot[1].position;
        }
        if (n == 3)
        {
            GameObject enemy2 = Instantiate(enemy_type2) as GameObject;
            enemy2.transform.position = spawn_spot[2].position;
        }
    }
    IEnumerator spawn2()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemy2_time);
            spawnEnemy2();
        }


    }
    public void spawnEnemy3()
    {
        int n = Random.Range(1, 4);
        if (n == 1)
        {
            GameObject enemy3 = Instantiate(enemy_type3) as GameObject;
            enemy3.transform.position = spawn_spot[0].position;

        }
        if (n == 2)
        {
            GameObject enemy3 = Instantiate(enemy_type3) as GameObject;
            enemy3.transform.position = spawn_spot[1].position;
        }
        if (n == 3)
        {
            GameObject enemy3 = Instantiate(enemy_type3) as GameObject;
            enemy3.transform.position = spawn_spot[2].position;
        }
    }
    IEnumerator spawn3()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemy3_time);
            spawnEnemy3();
        }


    }
    public void timeRedux()
    {
        enemy1_time -= 1f;
        enemy2_time -= 1f;
        enemy3_time -= 1f;
        if (enemy1_time < 1)
        {
            enemy1_time = 1;
        }
        if (enemy2_time < 1)
        {
            enemy2_time = 1;
        }
        if (enemy3_time < 1)
        {
            enemy3_time = 1;
        }
    }
    IEnumerator reduceTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);
            timeRedux();
        }
    }
}
