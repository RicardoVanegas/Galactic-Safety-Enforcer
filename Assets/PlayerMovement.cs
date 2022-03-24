using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int player_life = 100;
    public int player_damage = 50;
    public int player_speed = 5;
    public int player_firing_rate = 3;
    public int player_charger_size = 10;
    public float player_reload_time = 1.0f;
    private Transform player_transform;
    public GameObject laser;
    public Transform firePoint;
    private float firePointX;
    private float firePointY;


    // Start is called before the first frame update
    void Start()
    {
        player_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        attack();
        firePointPosition();
    }

    public void movement()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        player_transform.Translate(h * player_speed * Time.deltaTime, 0, 0);
        player_transform.Translate(0, v * player_speed * Time.deltaTime, 0);

    }

    public void attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject projectile = Instantiate(laser) as GameObject;
            projectile.transform.position = new Vector2(firePointX, firePointY);
        }
    }
    public void firePointPosition()
    {
        firePointX = firePoint.transform.position.x;
        firePointY = firePoint.transform.position.y + .7f;
    }
}
