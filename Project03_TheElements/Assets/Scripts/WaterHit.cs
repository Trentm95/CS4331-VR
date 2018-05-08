using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHit : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("fire"))
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<AIController>().Hit();
        }  
    }
}
