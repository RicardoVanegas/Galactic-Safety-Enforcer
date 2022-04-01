using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothership : MonoBehaviour
{
    public int health = 500;
    private int current_health;
    public GameObject explosion;
    public Transform explosion_position;
    public HealthBar healthBar;
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.setMaxHealth(health);
        current_health = health;
        StartCoroutine(attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            current_health -= FindObjectOfType<Enemy1>().damage;
            healthBar.setHealth(current_health);
            if (current_health <= 0)
            {
                death();
            }
        }
        
    }
    public void takeDamage(int n)
    {
        current_health -= n;
        healthBar.setHealth(current_health);
        if (current_health <= 0)
        {
            death();
        }
    }
    public void death()
    {
        FindObjectOfType<endGame>().LostGame((FindObjectOfType<PlayerMovement>().score), FindObjectOfType<survivedTime>().seconds_survived) ;
        GameObject explosion_anim = Instantiate(explosion) as GameObject;
        explosion_anim.transform.position = explosion_position.position;
        Destroy(this.gameObject);
        
    }
    public void fire()
    {
        GameObject laser1 = Instantiate(laser) as GameObject;
        GameObject laser2 = Instantiate(laser) as GameObject;
        GameObject laser3 = Instantiate(laser) as GameObject;
        laser1.transform.position = new Vector3(-7, -8, 0);
        laser2.transform.position = new Vector3(0, -8, 0);
        laser3.transform.position = new Vector3(7, -8, 0);
    }
    IEnumerator attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            fire();
        }


    }
}
