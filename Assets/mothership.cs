using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothership : MonoBehaviour
{
    public int health = 500;
    public GameObject explosion;
    public Transform explosion_position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            health -= FindObjectOfType<Enemy1>().damage;
            if(health <= 0)
            {
                death();
            }
        }
    }
    public void death()
    {
        GameObject explosion_anim = Instantiate(explosion) as GameObject;
        explosion_anim.transform.position = explosion_position.position;
        Destroy(this.gameObject);
        
    }
}
