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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Dasteroid = GetComponent<Transform>();
        getTarget();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    public void move()
    {
        
        Dasteroid.position = Vector2.MoveTowards(Dasteroid.position, target, 5 * Time.deltaTime);
    }
    public void getTarget()
    {
        if (Dasteroid.position.x < 0)
        {
            target = endRight.position;
        }
        else
        {
            target = endLeft.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            damaged();
        }
    }
    public void damaged()
    {
        health -= 30;
        if(health <= 0)
        {
            anim.SetTrigger("destroyed");
            Invoke("destroyed", .5f);
        }
    }
    public void destroyed()
    {
        Destroy(this.gameObject);
    }
}
