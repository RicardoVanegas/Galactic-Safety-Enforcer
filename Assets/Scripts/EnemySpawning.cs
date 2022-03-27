using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemy_type1;
    public Transform [] spawn_spot = new Transform[3];
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        StartCoroutine(spawn());
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
            yield return new WaitForSeconds(5);
            spawnEnemy();
        }
       
        
    }
}
