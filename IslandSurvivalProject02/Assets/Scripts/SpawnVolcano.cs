using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVolcano : MonoBehaviour
{
 
    public GameObject volcanoSystem;

    // Use this for initialization
    void Start()
    {
        volcanoSystem = Instantiate(volcanoSystem, new Vector3(-7, -277, 1640), volcanoSystem.transform.rotation);
   
    }        

    void OnDisable()
    {
        Destroy(volcanoSystem);
    }
}   