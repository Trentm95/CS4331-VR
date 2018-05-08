using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthHit : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("air"))
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<AIController>().Hit();
        }
    }
}
