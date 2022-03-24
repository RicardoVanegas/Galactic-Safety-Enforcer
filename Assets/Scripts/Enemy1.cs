using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public int  speed=3,
                 life=40;
    private Transform transform;
    private Collider2D coll;
    public PlayerMovement player;



    float x = 0;
    float y = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        movement();
        death();
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
            Destroy(this.gameObject);

        }
        if(collision.tag == "Player_Laser")
        {
            this.life = this.life - 10;  //esto va a cambiar para que coincida con el daño del jugador
            
        }
    }
    public void death()
    {
        if (this.life <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    void movement()
    {
        
        if(y < 15.0f)
        {
            y += .05f;
            transform.Translate( 0, speed * Time.deltaTime, 0);
        }
        else
        {
            if(x > -30f)
            {
                x -= .05f;
                transform.Translate(speed * Time.deltaTime,0, 0);
            }
            else
            {
                transform.Translate(0, speed * Time.deltaTime  , 0);
            }
        }
    }
}
