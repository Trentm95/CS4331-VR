using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) + OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger)  > 0)
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}
