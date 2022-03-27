using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public int deffault_speed = 2,
                attack_speed = 4,
                 life = 40,
                 damage = 40,
                 move_speed;
    private Transform enemy_transform;
    private Collider2D coll;
    public PlayerMovement player;
    public GameObject explosion;
    private Vector2 target;
    


    
    // Start is called before the first frame update
    void Start()
    {
        enemy_transform = GetComponent<Transform>();
        target = new Vector2(0, 0);
        move_speed = deffault_speed;
        
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
                target = new Vector2(-4, 4);
                
            }
            
        }
       if(enemy_transform.position.x == -8 && enemy_transform.position.y == 2 || enemy_transform.position.x == -4 && enemy_transform.position.y == 4)
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
        if (enemy_transform.position.x == -7 && enemy_transform.position.y == 4 || enemy_transform.position.x == 0 && enemy_transform.position.y == 2 || enemy_transform.position.x == 7 && enemy_transform.position.y == 4)
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6) //collision with a player/base bullet
        {
            if(collision.gameObject.tag == "bullet")
            {
                damaged(player.player_damage);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerMovement>().takeDamage(damage);
            GameObject explosion_anim = Instantiate(explosion) as GameObject;
            explosion_anim.transform.position = transform.position;
            Destroy(this.gameObject);
            

        }
        if(collision.tag == "Player_Laser")
        {
            this.life -= 10;  //esto va a cambiar para que coincida con el da�o del jugador
            
        }
    }
    public void death()
    {
        if (this.life <= 0)
        {
            GameObject explosion_anim = Instantiate(explosion) as GameObject;
            explosion_anim.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
   
   
}
