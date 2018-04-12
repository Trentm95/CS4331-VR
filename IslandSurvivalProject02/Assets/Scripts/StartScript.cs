using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {
	
	// Load Game on button press
	void Update () {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("SurvivalGame");
        }
    }
}
