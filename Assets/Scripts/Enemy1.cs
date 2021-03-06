using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float deffault_speed = 1.5f;
    public float move_speed;
    public int attack_speed = 3,
                 life = 40,
                 maxHealth = 40,
                 damage = 40;

                 
               
    private Transform enemy_transform;
    public GameObject explosion;
    private Vector2 target;
    private int points_for_death=25;
    private int gold_for_death = 5;

    public HealthBarBehaviour healthBar;

    
    // Start is called before the first frame update
    void Start()
    {
        enemy_transform = GetComponent<Transform>();
        target = new Vector2(0, 0);
        move_speed = deffault_speed;
        healthBar.setHealth(life, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        death();
        move();
    }
    public void move()
    {
        
        
        //this is for the spawn position 1


        if (enemy_transform.position.x == -8 && enemy_transform.position.y == 6 )
        {
            target = new Vector2(-8, 4);
        } 
        if (enemy_transform.position.x == -8 && enemy_transform.position.y == 4)
        {
            int n = Random.Range(1, 3);
            if (n == 1)
            {
                target = new Vector2(-8, 2);
                
            }
            if(n== 2)
            {
                target = new Vector2(-1, 4);
                
            }
            
        }
       if(enemy_transform.position.x == -8 && enemy_transform.position.y == 2 || enemy_transform.position.x == -1 && enemy_transform.position.y == 4)
        {
            move_speed = attack_speed;
            Invoke("attack", .5f);
        }



        //this is for the spawn position 2
        if (enemy_transform.position.x == 0 && enemy_transform.position.y == 6)
        {
            target = new Vector2(0, 4);
        }
        if (enemy_transform.position.x == 0 && enemy_transform.position.y == 4)
        {
            int n = Random.Range(1, 4);
            if (n == 1)
            {
                target = new Vector2(-7, 4);

            }
            if (n == 2)
            {
                target = new Vector2(0, 2);

            }
            if (n == 3)
            {
                target = new Vector2(6, 4);
            }
        }
        if (enemy_transform.position.x == -7 && enemy_transform.position.y == 4 || enemy_transform.position.x == 0 && enemy_transform.position.y == 2 || enemy_transform.position.x == 6 && enemy_transform.position.y == 4)
        {
            move_speed = attack_speed;
            Invoke("attack", .5f);
        }

        //this is for the spawn position 3
        if (enemy_transform.position.x == 7 && enemy_transform.position.y == 6)
        {
            target = new Vector2(7, 4);
        }
        if (enemy_transform.position.x == 7 && enemy_transform.position.y == 4)
        {
            int n = Random.Range(1, 3);
            if (n == 1)
            {
                target = new Vector2(1, 4);

            }
            if (n == 2)
            {
                target = new Vector2(7, 2);

            }

        }
        if (enemy_transform.position.x == 1 && enemy_transform.position.y == 4 || enemy_transform.position.x == 7 && enemy_transform.position.y == 2)
        {
            move_speed = attack_speed;
            Invoke("attack", .5f);
        }

        //this is for the movement in any initial position
        enemy_transform.position = Vector2.MoveTowards(enemy_transform.position, target, move_speed * Time.deltaTime);
        
    }
    public void attack()
    {
        target = new Vector2(enemy_transform.position.x, -8);
        
        
    }



    void damaged(int dmg)
    {
        this.life -= dmg;
        healthBar.setHealth(life, maxHealth);
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            FindObjectOfType<PlayerMovement>().givePoints(points_for_death);
            FindObjectOfType<PlayerMovement>().giveGold(gold_for_death);
            FindObjectOfType<PlayerMovement>().takeDamage(damage);
            GameObject explosion_anim = Instantiate(explosion) as GameObject;
            explosion_anim.transform.position = transform.position;
            Destroy(this.gameObject);
            

        }
        if (collision.tag == "Mothership")
        {
            GameObject explosion_anim = Instantiate(explosion) as GameObject;
            explosion_anim.transform.position = transform.position;
            Destroy(this.gameObject);
        }
        if(collision.tag == "Player_Laser")
        {
            damaged(FindObjectOfType<PlayerMovement>().player_damage);
            
        }
        if(collision.tag == "MothershipLaser")
        {
            damaged(FindObjectOfType<mothership>().damage);
        }
        if(collision.tag == "asteroid")
        {
            GameObject explosion_anim = Instantiate(explosion) as GameObject;
            explosion_anim.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
    public void death()
    {
        if (this.life <= 0)
        {
            FindObjectOfType<PlayerMovement>().givePoints(points_for_death);
            FindObjectOfType<PlayerMovement>().giveGold(gold_for_death);
            GameObject explosion_anim = Instantiate(explosion) as GameObject;
            explosion_anim.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
    
   
   
}
