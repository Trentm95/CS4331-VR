using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {
	
	// Load Game on button press
	void Update () {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) + OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
        {
            SceneManager.LoadScene("main-oculus");
        }
    }
}
