using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text Livenumber;
    public Text Scorenumber;
    private int Scorenum;
    private int Livenum;
    [SerializeField] private GameObject lastFloor;
   
    
    // Start is called before the first frame update
    void Start()
    {
        Scorenum = 0;
        Livenum = 3;
        Scorenumber.text = "FOOD : " + Scorenum;
        Livenumber.text = "LIVE : " + Livenum;
    }

    // Update is called once per frame
    void Update()
    {
        if (Livenum <= 0)
        {
            SceneManager.LoadScene("Gameplay");
        }

        if (Scorenum >=5)
        {
            Destroy(lastFloor);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D Point)
    {
        if(Point.tag == "Point")
        {
            Scorenum++;
            Destroy(Point.gameObject);//destroy when the player touches the coin
            Scorenumber.text = "FOOD : " + Scorenum;
        }
        
        if (Point.tag == "PoisonFood")
        {
            Livenum--;
            Destroy(Point.gameObject);//destroy when the player touches the coin
            Livenumber.text = "LIVE : " + Livenum;
        }
        
    }

}
