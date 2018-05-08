using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHit : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("earth"))
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<AIController>().Hit();
        }
    }
}
