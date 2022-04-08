using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public int speed = 4;
    public int health = 50;
    public int damage = 15;
    private int damage_on_collision = 40;
    private Transform enemy_transform;
    private Vector2 target;
    private int points_for_death = 50;
    private int gold_for_death = 10;
    public GameObject explosion;
    public GameObject laser_enemy;
    public Transform firePointPosition;
    // Start is called before the first frame update
    void Start()
    {
        enemy_transform = GetComponent<Transform>();
        target = new Vector2(0, 0);
        StartCoroutine(attacking());
    }

    // Update is called once per frame
    void Update()
    {
        move();
        death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<PlayerMovement>().givePoints(points_for_death);
            FindObjectOfType<PlayerMovement>().giveGold(gold_for_death);
            FindObjectOfType<PlayerMovement>().takeDamage(damage_on_collision);
            GameObject explosion_anim = Instantiate(explosion) as GameObject;
            explosion_anim.transform.position = transform.position;
            Destroy(this.gameObject);
        }
        if (collision.tag == "Player_Laser")
        {
            damaged(FindObjectOfType<PlayerMovement>().player_damage);
        }
        if (collision.tag == "MothershipLaser")
        {
            damaged(FindObjectOfType<mothership>().damage);
        }
    }
    public void damaged(int dmg)
    {
        health -= dmg;
    }
    public void death()
    {
        if (health <= 0)
        {
            FindObjectOfType<PlayerMovement>().givePoints(points_for_death);
            FindObjectOfType<PlayerMovement>().giveGold(gold_for_death);
            GameObject explosion_anim = Instantiate(explosion) as GameObject;
            explosion_anim.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
    public void attack()
    {
        GameObject laser = Instantiate(laser_enemy) as GameObject;
        laser.transform.position = firePointPosition.position;
    }
    IEnumerator attacking()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            attack();
        }
    }

    public void move()
    {

        //this part is for spawn positions
        if(enemy_transform.position.x == -8 && enemy_transform.position.y == 6)
        {
            target = new Vector2(-8, 4);
        }
        if (enemy_transform.position.x == 0 && enemy_transform.position.y == 6)
        {
            target = new Vector2(0, 4);
        }
        if (enemy_transform.position.x == 7 && enemy_transform.position.y == 6)
        {
            target = new Vector2(7, 4);
        }

        //this part is for the map position
        if (enemy_transform.position.x == -8 && enemy_transform.position.y == 4)
        {
            target = newTargetFrom1();
        }
        if (enemy_transform.position.x == 0 && enemy_transform.position.y == 4)
        {
            target = newTargetFrom2();
        }
        if (enemy_transform.position.x == 7 && enemy_transform.position.y == 4)
        {
            target = newTargetFrom3();
        }
        if (enemy_transform.position.x == -8 && enemy_transform.position.y == 2)
        {
            target = newTargetFrom4();
        }
        if (enemy_transform.position.x == 0 && enemy_transform.position.y == 2)
        {
            target = newTargetFrom5();
        }
        if (enemy_transform.position.x == 7 && enemy_transform.position.y == 2)
        {
            target = newTargetFrom6();
        }
        enemy_transform.position = Vector2.MoveTowards(enemy_transform.position, target, speed * Time.deltaTime);

    }
    public Vector2 newTargetFrom1()
    {
        int n = Random.Range(1, 3);
        if(n == 1)
        {
            return new Vector2(0, 4);
        }
        else if (n == 2)
        {
            return new Vector2(-8, 2);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }
    public Vector2 newTargetFrom2()
    {
        int n = Random.Range(1, 4);
        if (n == 1)
        {
            return new Vector2(-8, 4);
        }
        else if (n == 2)
        {
            return new Vector2(7, 4);
        }
        else if(n==3)
        {
            return new Vector2(0, 2);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }
    public Vector2 newTargetFrom3()
    {
        int n = Random.Range(1, 3);
        if (n == 1)
        {
            return new Vector2(0, 4);
        }
        else if (n == 2)
        {
            return new Vector2(7, 2);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }
    public Vector2 newTargetFrom4()
    {
        int n = Random.Range(1, 3);
        if (n == 1)
        {
            return new Vector2(-8, 4);
        }
        else if (n == 2)
        {
            return new Vector2(0, 2);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }
    public Vector2 newTargetFrom5()
    {
        int n = Random.Range(1, 4);
        if (n == 1)
        {
            return new Vector2(0, 4);
        }
        else if (n == 2)
        {
            return new Vector2(-8, 2);
        }
        else if (n == 3)
        {
            return new Vector2(7, 2);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }
    public Vector2 newTargetFrom6()
    {
        int n = Random.Range(1, 3);
        if (n == 1)
        {
            return new Vector2(7, 4);
        }
        else if (n == 2)
        {
            return new Vector2(0, 2);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }
}
