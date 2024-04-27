using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyed : MonoBehaviour
{
    private int timer = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( timer <=0)
        {
            Destroy(gameObject); 
        }
        else
        {
            timer--;
        }
    }
}
