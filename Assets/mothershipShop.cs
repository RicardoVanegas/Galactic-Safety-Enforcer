using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mothershipShop : MonoBehaviour
{
    public int h_level;
    public int d_level;
    public int f_level;

    public int h_cost;
    public int d_cost;
    public int f_cost;

    public int cost;
    public int gold;

    public Text cost_h;
    public Text cost_d;
    public Text cost_f;
    public Text h_lev;
    public Text d_lev;
    public Text f_lev;
    public Text gold_text;

    public GameObject upgrade_text;
    public GameObject max_text;

    public playerData player_data;

    // Start is called before the first frame update
    void Start()
    {
        MothershipData data = SaveSystem.LoadBase();
        player_data = SaveSystem.LoadPlayer();
        h_level = data.health_level;
        d_level = data.damage_level;
        f_level = data.firingRate_level;
        gold = player_data.gold_amount;

        h_lev.text = h_level.ToString();
        d_lev.text = d_level.ToString();
        f_lev.text = f_level.ToString();
        gold_text.text = gold.ToString();

        cost_h.text = ((Mathf.Pow(2, h_level)) * 100).ToString();
        cost_d.text = ((Mathf.Pow(2, d_level)) * 100).ToString();
        cost_f.text = ((Mathf.Pow(2, f_level)) * 100).ToString();
        if(h_level == 5)
        {
            cost_h.text = "0";
        }
        if (d_level == 5)
        {
            cost_d.text = "0";
        }
        if (f_level == 5)
        {
            cost_f.text = "0";
        }
    }

    public void upgradeHealth()
    {
        cost = (int)((Mathf.Pow(2, h_level)) * 100);

        if (h_level < 5)
        {
            if (gold >= cost)
            {
                gold -= cost;
                h_level++;
                cost = (int)((Mathf.Pow(2, h_level)) * 100);
                cost_h.text = cost.ToString();
                h_lev.text = h_level.ToString();
                upgrade_text.SetActive(true);
                gold_text.text = gold.ToString();
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
        cost = (int)((Mathf.Pow(2, d_level)) * 100);

        if (d_level < 5)
        {
            if (gold >= cost)
            {
                gold -= cost;
                d_level++;
                cost = (int)((Mathf.Pow(2, d_level)) * 100);
                cost_d.text = cost.ToString();
                d_lev.text = d_level.ToString();
                upgrade_text.SetActive(true);
                gold_text.text = gold.ToString();
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
        cost = (int)((Mathf.Pow(2, f_level)) * 100);

        if (f_level < 5)
        {
            if (gold >= cost)
            {
                gold -= cost;
                f_level++;
                cost = (int)((Mathf.Pow(2, f_level)) * 100);
                cost_f.text = cost.ToString();
                f_lev.text = f_level.ToString();
                upgrade_text.SetActive(true);
                gold_text.text = gold.ToString();
                Invoke("dissappearUpgrade", .5f);
            }
        }
        else
        {
            max_text.SetActive(true);
            Invoke("dissappearMax", .5f);
        }
    }
    public void backButton()
    {
        SaveSystem.saveBaseFromShop(this);
        SaveSystem.savePlayerFromMShop(player_data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
