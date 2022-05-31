using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_laser : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 30f;
    private int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        damage = FindObjectOfType<Enemy2>().damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<PlayerMovement>().takeDamage(damage);
            Destroy(this.gameObject);
        }
        if(collision.tag == "Mothership")
        {
            FindObjectOfType<mothership>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
