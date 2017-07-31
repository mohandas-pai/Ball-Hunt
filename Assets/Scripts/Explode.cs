using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    public GameObject mExplosionPrefab;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "hat")
        {
            Instantiate(mExplosionPrefab, transform.position + new Vector3(0,0,-2) , transform.rotation);
        }
    }
	
}
