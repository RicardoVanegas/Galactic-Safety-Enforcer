using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShop : MonoBehaviour
{
    public int health_level;
    public int speed_level;
    public int damage_level;
    public int firingRate_level;
    public int reloadSpeed_level;
    public int ammo_level;
    public int gold_amount;
    public int higher_score;

    private int cost;

    public Text h_level;
    public Text h_cost;
    public Text s_level;
    public Text s_cost;
    public Text d_level;
    public Text d_cost;
    public Text f_level;
    public Text f_cost;
    public Text r_level;
    public Text r_cost;
    public Text a_level;
    public Text a_cost;

    public Text gold_text;

    public GameObject upgrade_text;
    public GameObject max_text;



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
        gold_amount = data.gold_amount;
        higher_score = data.higher_score;

        gold_text.text = gold_amount.ToString();
        h_level.text = health_level.ToString();
        s_level.text = speed_level.ToString();
        d_level.text = damage_level.ToString();
        f_level.text = firingRate_level.ToString();
        r_level.text = reloadSpeed_level.ToString();
        a_level.text = ammo_level.ToString();

        if (health_level < 5)
        {
            cost = (int)(Mathf.Pow(2, (health_level - 1))) * 100;
            h_cost.text = cost.ToString();
        }
        else
        {
            cost = 0;
            h_cost.text = cost.ToString();
        }

        if (speed_level < 5)
        {
            cost = (int)(Mathf.Pow(2, (speed_level - 1))) * 100;
            s_cost.text = cost.ToString();
        }
        else
        {
            cost = 0;
            s_cost.text = cost.ToString();
        }

        if (damage_level < 5)
        {
            cost = (int)(Mathf.Pow(2, (damage_level - 1))) * 100;
            d_cost.text = cost.ToString();
        }
        else
        {
            cost = 0;
            d_cost.text = cost.ToString();
        }

        if (firingRate_level < 5)
        {
            cost = (int)(Mathf.Pow(2, (firingRate_level - 1))) * 100;
            f_cost.text = cost.ToString();
        }
        else
        {
            cost = 0;
            f_cost.text = cost.ToString();
        }

        if (reloadSpeed_level < 5)
        {
            cost = (int)(Mathf.Pow(2, (reloadSpeed_level - 1))) * 100;
            r_cost.text = cost.ToString();
        }
        else
        {
            cost = 0;
            r_cost.text = cost.ToString();
        }

        if (ammo_level < 5)
        {
            cost = (int)(Mathf.Pow(2, (ammo_level - 1))) * 100;
            a_cost.text = cost.ToString();
        }
        else
        {
            cost = 0;
            a_cost.text = cost.ToString();
        }

    }
    public void backButton()
    {
        SaveSystem.savePlayerFromShop(this);
    }

    public void upgradeHealth()
    {
        cost = (int) (Mathf.Pow(2, (health_level-1))) * 100;
        
        if(health_level < 5)
        {
            if (gold_amount >= cost)
            {
                gold_amount -= cost;
                health_level++;
                cost = (int)(Mathf.Pow(2, (health_level - 1))) * 100;
                h_cost.text = cost.ToString();
                h_level.text = health_level.ToString();
                upgrade_text.SetActive(true);
                gold_text.text = gold_amount.ToString();
                Invoke("dissappearUpgrade", .5f);
            }
        }
        else
        {
            max_text.SetActive(true);
            Invoke("dissappearMax", .5f);
        }
        
       
    }
    public void upgradeSpeed()
    {
        cost = (int)(Mathf.Pow(2, (speed_level - 1))) * 100;

        if (speed_level < 5)
        {
            if (gold_amount >= cost)
            {
                gold_amount -= cost;
                speed_level++;
                cost = (int)(Mathf.Pow(2, (speed_level - 1))) * 100;
                s_cost.text = cost.ToString();
                s_level.text = speed_level.ToString();
                upgrade_text.SetActive(true);
                gold_text.text = gold_amount.ToString();
                Invoke("dissappearUpgrade", .5f);
            }
        }
        else
        {
            max_text.SetActive(true);
            Invoke("dissappearMax", .5f);
        }
    }
    public void upgradeDamage()
    {
        cost = (int)(Mathf.Pow(2, (damage_level - 1))) * 100;

        if (damage_level < 5)
        {
            if (gold_amount >= cost)
            {
                gold_amount -= cost;
                damage_level++;
                cost = (int)(Mathf.Pow(2, (damage_level - 1))) * 100;
                d_cost.text = cost.ToString();
                d_level.text = damage_level.ToString();
                upgrade_text.SetActive(true);
                gold_text.text = gold_amount.ToString();
                Invoke("dissappearUpgrade", .5f);
            }
        }
        else
        {
            max_text.SetActive(true);
            Invoke("dissappearMax", .5f);
        }
    }
    public void upgradeFiringRate()
    {
        cost = (int)(Mathf.Pow(2, (firingRate_level - 1))) * 100;

        if (firingRate_level < 5)
        {
            if (gold_amount >= cost)
            {
                gold_amount -= cost;
                firingRate_level++;
                cost = (int)(Mathf.Pow(2, (firingRate_level - 1))) * 100;
                f_cost.text = cost.ToString();
                f_level.text = firingRate_level.ToString();
                upgrade_text.SetActive(true);
                gold_text.text = gold_amount.ToString();
                Invoke("dissappearUpgrade", .5f);
            }
        }
        else
        {
            max_text.SetActive(true);
            Invoke("dissappearMax", .5f);
        }
    }
    public void upgradeReloadSpeed()
    {
        cost = (int)(Mathf.Pow(2, (reloadSpeed_level - 1))) * 100;

        if (reloadSpeed_level < 5)
        {
            if (gold_amount >= cost)
            {
                gold_amount -= cost;
                reloadSpeed_level++;
                cost = (int)(Mathf.Pow(2, (reloadSpeed_level - 1))) * 100;
                r_cost.text = cost.ToString();
                r_level.text = reloadSpeed_level.ToString();
                upgrade_text.SetActive(true);
                gold_text.text = gold_amount.ToString();
                Invoke("dissappearUpgrade", .5f);
            }
        }
        else
        {
            max_text.SetActive(true);
            Invoke("dissappearMax", .5f);
        }
    }
    public void upgradeAmmo()
    {
        cost = (int)(Mathf.Pow(2, (ammo_level - 1))) * 100;

        if (ammo_level < 5)
        {
            if (gold_amount >= cost)
            {
                gold_amount -= cost;
                ammo_level++;
                cost = (int)(Mathf.Pow(2, (ammo_level - 1))) * 100;
                a_cost.text = cost.ToString();
                a_level.text = ammo_level.ToString();
                upgrade_text.SetActive(true);
                gold_text.text = gold_amount.ToString();
                Invoke("dissappearUpgrade", .5f);
            }
        }
        else
        {
            max_text.SetActive(true);
            Invoke("dissappearMax", .5f);
        }
    }
    public void dissappearMax()
    {
        max_text.SetActive(false);
    }
    public void dissappearUpgrade()
    {
        upgrade_text.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
