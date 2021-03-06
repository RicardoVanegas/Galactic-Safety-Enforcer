using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAsteroids : MonoBehaviour
{

    public GameObject Dasteroid;
    public Transform dPositionRight;
    public Transform dPositionLeft;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnDiagonalAsteroids());
        StartCoroutine(spawnFAsteroids());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void diagonalAsteroids()
    {
        int n = Random.Range(1, 3);
        if (n == 1)
        {
            GameObject asteroid = Instantiate(Dasteroid) as GameObject;
            asteroid.transform.position = dPositionRight.position;
            
        }
        if (n == 2)
        {
            GameObject asteroid = Instantiate(Dasteroid) as GameObject;
            asteroid.transform.position = dPositionLeft.position;
        }
        
    }

    public void Asteroids()
    {
        int n = Random.Range(-7,8);
        GameObject asteroid = Instantiate(Dasteroid) as GameObject;
        asteroid.transform.position = new Vector3(n, 8, 0);
    }
    IEnumerator spawnFAsteroids()
    {
        while (true)
        {
            yield return new WaitForSeconds(12f);
            Asteroids();
        }
    }
    IEnumerator spawnDiagonalAsteroids()
    {
        while (true)
        {
            yield return new WaitForSeconds(7.5f);
            diagonalAsteroids();
        }
    }
}
