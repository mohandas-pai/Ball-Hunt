using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOb : MonoBehaviour {

	// Use this for initialization
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (hatcontrol.destob == true)
        {
            Destroy(other.gameObject);
        }
    }
}
