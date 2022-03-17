using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public int  speed=1,
                 fire_rate=10,
                 life=51;
    public Transform transform;
    public Collider2D coll;
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

    void movement()
    {
        
        if(y < 15.0f)
        {
            y += .05f;
            transform.Translate( 0, speed * Time.deltaTime*.1f, 0);
        }
        else
        {
            if(x > -30f)
            {
                x -= .05f;
                transform.Translate(speed * Time.deltaTime*.1f,0, 0);
            }
            else
            {
                transform.Translate(0, speed * Time.deltaTime * .1f, 0);
            }
        }
    }
}
