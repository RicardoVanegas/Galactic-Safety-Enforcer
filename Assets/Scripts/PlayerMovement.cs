using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public int player_life = 100;
    public int player_damage = 10;
    public int player_speed = 5;
    public float player_firing_rate = 1f;
    private float next_Time_To_Fire = 0f;
    public int ammo = 10;
    public float player_reload_time = 1.0f;
    private Transform player_transform;
    public GameObject laser;
    public Transform firePoint;
    private float firePointX;
    private float firePointY;
    private int count = 0;
    public Text ammunition_text;
    private bool reloading;
    // Start is called before the first frame update
    void Start()
    {
        player_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        ammunition();
        firePointPosition();
        attack();



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
        if (Input.GetKeyDown(KeyCode.J) && Time.time >= next_Time_To_Fire)
        {
            next_Time_To_Fire = Time.time + 1f / player_firing_rate;
            GameObject projectile = Instantiate(laser) as GameObject;
            projectile.transform.position = new Vector2(firePointX, firePointY);
            ammo--;
        }

    }
    public void firePointPosition()
    {
        firePointX = firePoint.transform.position.x;
        firePointY = firePoint.transform.position.y;
    }
    public void ammunition()
    {
        ammunition_text.text = ammo.ToString();
        if (ammo == 0)
        {

        }
    }
}
