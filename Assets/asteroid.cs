using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    private Transform Dasteroid;
    public Transform dSpawnL;
    public Transform dSpawnR;
    public Transform endRight;
    public Transform endLeft;
    private Animator anim;
    public int health=100;
    private Vector2 target;
    public int velocity;
    private CircleCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Dasteroid = GetComponent<Transform>();
        getTarget();
        getVelocity();
        coll = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    public void move()
    {
        
        Dasteroid.position = Vector2.MoveTowards(Dasteroid.position, target, velocity * Time.deltaTime);
    }
    public void getVelocity()
    {
        if (Dasteroid.position.x < -9)
        {
            velocity = 5;
        }
        if(Dasteroid.position.x > 10)
        {
            velocity = 5;
        }
        if(Dasteroid.position.x > -7 && Dasteroid.position.x < 8)
        {
            velocity = 2;
        }
        
    }
    public void getTarget()
    {
        if (Dasteroid.position.x < -9)
        {
            target = endRight.position;
        }
        if (Dasteroid.position.x > 10)
        {
            target = endLeft.position;
        }
        if (Dasteroid.position.x > -7 && Dasteroid.position.x < 7)
        {
            int n = Random.Range(-7, 8);
            target = new Vector3(n, -10, 0);
        }
        
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            damagedByCollision();
        }
        if(collision.tag == "Player")
        {
            damagedByCollision();
            FindObjectOfType<PlayerMovement>().takeDamage(300);
        }
        if(collision.tag == "Player_Laser")
        {
            damaged(FindObjectOfType<PlayerMovement>().player_damage);
            
        }
        if (collision.tag == "endAsteroid")
        {
            Destroy(this.gameObject);
        }
        if(collision.tag == "Mothership")
        {
            damaged(300);
            FindObjectOfType<mothership>().takeDamage(45);
        }
        if (collision.tag == "MothershipLaser")
        {
            damaged(FindObjectOfType<mothership>().damage);
        }
        
    }
    public void damagedByCollision()
    {
        health -= 30;
        if(health <= 0)
        {
            anim.SetTrigger("destroyed");
            Invoke("destroyed", .5f);
        }
    }
    public void damaged(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            coll.enabled = false;
            anim.SetTrigger("destroyed");
            Invoke("destroyed", .8f);
        }
    }
    public void destroyed()
    {
        Destroy(this.gameObject);
    }
}
