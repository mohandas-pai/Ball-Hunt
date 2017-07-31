using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour {
    public int countb = 0, countbo = 0, countsp = 0;
    public static bool balllife=false;
    public static bool bomblife=false;
    public static bool speciallife = false;
    public static bool flagg = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        flagg = true;

        if (other.transform.tag == "Ball")
        {
            countb++;
            Debug.Log("Ball Count : " + countb);
            if (countb == 5)
            {
                balllife = true;
                countb = 0;
            }
        }
        else if (other.transform.tag == "Bomb")
        {
            
            countbo++;
            Debug.Log("Bomb Count : " + countbo);
            if (countbo==10)
            {
                bomblife = true;
                countbo = 0;
            }
        }
        else if (other.transform.tag == "Special")
        {
            countsp++;
            Debug.Log("Special Count : " + countsp);
            if (countsp == 3)
            {
                speciallife = true;
                countsp = 0;
            }
        }
    }
}
