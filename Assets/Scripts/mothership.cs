using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothership : MonoBehaviour
{
    public int h_level;
    public int d_level;
    public int f_level;

    public int health;
    public int damage;
    public float firingRate;
    private int current_health;
    public GameObject explosion;
    public Transform explosion_position;
    public HealthBar healthBar;
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        MothershipData data = SaveSystem.LoadBase();
        h_level = data.health_level;
        d_level = data.damage_level;
        f_level = data.firingRate_level;

        if (h_level == 1)
        {
            health = 500;
        }
        else
        {
            health = 500 + (250 * (h_level - 1));
        }

        healthBar.setMaxHealth(health);
        current_health = health;

        if(d_level ==1)
        {
            damage = 100;
        }
        else
        {
            damage = 100 + (20 * (d_level - 1));
        }
        if (f_level == 1)
        {
            firingRate = 16;
        }
        else
        {
            firingRate = 16 - (1.5f * (f_level - 1));
        }
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
        FindObjectOfType<PlayerMovement>().BaseDestroyed();
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
            yield return new WaitForSeconds(firingRate);
            fire();
        }


    }
}
