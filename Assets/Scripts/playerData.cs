using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData 
{
    public int health_level;
    public int speed_level;
    public int damage_level;
    public int firingRate_level;
    public int reloadSpeed_level;
    public int ammo_level;
    public int gold_amount;
    public int higher_score;
    
    public playerData()
    {
        health_level = 1;
        speed_level = 1;
        damage_level = 1;
        firingRate_level = 1;
        reloadSpeed_level = 1;
        ammo_level = 1;
        gold_amount = 0;
        higher_score = 0;
    }
    public playerData(PlayerMovement player)
    {
        health_level = player.health_level;
        speed_level = player.speed_level;
        damage_level = player.damage_level;
        firingRate_level = player.firingRate_level;
        reloadSpeed_level = player.reloadSpeed_level;
        ammo_level = player.ammo_level;
        gold_amount = player.gold;
        higher_score = player.higher_score;
    }
}
