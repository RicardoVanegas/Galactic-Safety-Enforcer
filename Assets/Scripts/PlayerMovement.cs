using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int health_level;
    public int speed_level;
    public int damage_level;
    public int firingRate_level;
    public int reloadSpeed_level;
    public int ammo_level;
    public int gold_saved;
    public int higher_score;

    public int player_life;
    private int player_current_life;
    public int player_damage;
    public float player_speed;
    public float player_firing_rate;
    private float next_Time_To_Fire;
    private int current_ammo;
    public int ammo;
    public float player_reload_time;
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
    public int gold;
    public int score;
    public Text gold_text;
    public Text score_text;
    public int actual_score;

    private SpriteRenderer playerSprite;
    

    // Start is called before the first frame update
    void Start()
    {
        playerData data = SaveSystem.LoadPlayer();
        health_level = data.health_level;
        speed_level = data.speed_level;
        damage_level = data.damage_level;
        firingRate_level = data.firingRate_level;
        reloadSpeed_level = data.reloadSpeed_level;
        ammo_level = data.ammo_level;
        gold_saved = data.gold_amount;
        higher_score = data.higher_score;

        player_life = health_level * 50;
        player_damage = damage_level * 10;
        player_speed = 5 + ((speed_level - 1) * .5f);
        player_firing_rate = 1 + ((firingRate_level -1) * .25f);
        player_reload_time = 3 - ((reloadSpeed_level-1)*.25f);
        ammo = ammo_level * 10;
        gold = gold_saved;
        

        player_transform = GetComponent<Transform>();
        current_ammo = ammo;
        player_current_life = player_life;
        healthBar.setMaxHealth(player_life);
        
        score = 0;
        gold_text.text = gold_saved.ToString();

        playerSprite = GetComponent<SpriteRenderer>();
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

        if (player_current_life <= 0)
        {
            actual_score = (int)(score + .5 * FindObjectOfType<survivedTime>().seconds_survived);
            if (actual_score > higher_score)
            {
                higher_score = actual_score;
            }

            

            GameObject explosion_anim = Instantiate(explosion) as GameObject;
            explosion_anim.transform.position = player_transform.position;

            
            FindObjectOfType<endGame>().LostGame(actual_score,FindObjectOfType<survivedTime>().seconds_survived, higher_score);

            playerSprite.gameObject.SetActive(false);
            SaveSystem.savePlayer(this);
            //Destroy(this.gameObject);
        }

    }
    public void BaseDestroyed()
    {
        actual_score = (int)(score + .5 * FindObjectOfType<survivedTime>().seconds_survived);
        if (actual_score > higher_score)
        {
            higher_score = actual_score;
        }
        FindObjectOfType<endGame>().LostGame(actual_score, FindObjectOfType<survivedTime>().seconds_survived, higher_score);

        playerSprite.gameObject.SetActive(false);
        SaveSystem.savePlayer(this);
    }
    public void givePoints(int n)
    {
        
        score += n;
        score_text.text = score.ToString();
        
    }
    public void giveGold(int n)
    {
        
        gold_saved += n;
        
        gold_text.text = gold_saved.ToString();
    }
   
   
    

   
}
