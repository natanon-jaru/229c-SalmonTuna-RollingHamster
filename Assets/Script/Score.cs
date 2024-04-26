using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Livenumber;
    public Text Scorenumber;
    private int Scorenum;
    private int Livenum;
    
    // Start is called before the first frame update
    void Start()
    {
        Scorenum = 0;
        Livenum = 3;
        Scorenumber.text = "SCORE : " + Scorenum;
        Livenumber.text = "LIVE : " + Livenum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D Point)
    {
        if(Point.tag == "Point")
        {
            Scorenum++;
            Destroy(Point.gameObject);//destroy when the player touches the coin
            Scorenumber.text = "SCORE : " + Scorenum;
        }
        
        if (Point.tag == "PoisonFood")
        {
            Livenum--;
            Destroy(Point.gameObject);//destroy when the player touches the coin
            Livenumber.text = "LIVE : " + Livenum;
        }

        // if (Point.tag == "Trap")
        // {
        //     Livenum--;
        //     Destroy(Point.gameObject);
        //     Livenumber.text = "LIVE : " + Livenum;
        //     
        // }
    }
}
