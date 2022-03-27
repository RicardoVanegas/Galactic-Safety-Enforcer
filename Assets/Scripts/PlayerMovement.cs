using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public int player_life = 50;
    private int player_current_life;
    public int player_damage = 10;
    public int player_speed = 5;
    public float player_firing_rate = 1f;
    private float next_Time_To_Fire = 0f;
    private int current_ammo;
    public int ammo = 10;
    public float player_reload_time = 3f;
    private Transform player_transform;
    public GameObject laser;
    public Transform firePoint;
    private float firePointX;
    private float firePointY;
    public Text ammunition_text;
    private bool reloading;
    public GameObject loading_anim;
    public Transform loading_position;
    public HealthBar healthBar;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        player_transform = GetComponent<Transform>();
        current_ammo = ammo;
        player_current_life = player_life;
        healthBar.setMaxHealth(player_life);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
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
        ammunition_text.text = current_ammo.ToString();
        if (Input.GetKeyDown(KeyCode.J) && Time.time >= next_Time_To_Fire && !reloading)
        {
            next_Time_To_Fire = Time.time + 1f / player_firing_rate;
            GameObject projectile = Instantiate(laser) as GameObject;
            projectile.transform.position = new Vector2(firePointX, firePointY);
            current_ammo--;
            if (current_ammo == 0)
            {
                reloading = true;
                StartCoroutine(reload_ammunition());

            }
        }
    }
    public void firePointPosition()
    {
        firePointX = firePoint.transform.position.x;
        firePointY = firePoint.transform.position.y;
    }
    IEnumerator reload_ammunition()
    {
        GameObject loading_object = Instantiate(loading_anim) as GameObject;
        loading_object.transform.position = loading_position.position;
        yield return new WaitForSeconds(player_reload_time);
        current_ammo = ammo;
        reloading = false;
        Destroy(loading_object);
    }
    public void takeDamage(int damage)
    {
        player_current_life -=  damage;
        healthBar.setHealth(player_current_life);
        if (player_current_life<=0)
        {
            GameObject explosion_anim = Instantiate(explosion) as GameObject;
            explosion_anim.transform.position = player_transform.position;
            Destroy(this.gameObject);
        }
    }
   
}
