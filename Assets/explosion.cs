using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("endExplosion", .5f);
    }

    public void endExplosion()
    {
        Destroy(this.gameObject);
    }
    
}
