using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothershipLaser : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser Limit")
        {
            Destroy(this.gameObject);
        }
    }
}
