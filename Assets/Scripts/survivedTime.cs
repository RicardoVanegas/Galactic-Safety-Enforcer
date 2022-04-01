using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class survivedTime : MonoBehaviour
{
    public int seconds_survived = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(time());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void seconds()
    {
        seconds_survived++;
    }
    IEnumerator time()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            seconds();
        }
    }
}
