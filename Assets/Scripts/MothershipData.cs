using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MothershipData
{
    public int health_level;
    public int damage_level;
    public int firingRate_level;

    public MothershipData()
    {
        health_level = 1; 
        damage_level = 1;
        firingRate_level = 1;
      
    }
    public MothershipData(mothership mothership)
    {
        health_level = mothership.h_level;
        damage_level = mothership.d_level;
        firingRate_level = mothership.f_level;
       
    }
    public MothershipData(mothershipShop mothership)
    {
        health_level = mothership.h_level;
        damage_level = mothership.d_level;
        firingRate_level = mothership.f_level;
        

    }
}
