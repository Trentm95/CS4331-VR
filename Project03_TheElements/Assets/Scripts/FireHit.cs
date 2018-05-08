using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHit : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("water"))
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<AIController>().Hit();
        }
    }
}
