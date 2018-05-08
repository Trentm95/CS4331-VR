using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundControl : MonoBehaviour {
	// Update is called once per frame
	void Update () {

        // If player has killed all enemies, increment to next round and reload scene
        if (ProgressionInterface.getEnemyCount() < 1)
        {
            ProgressionInterface.IncRound();
            SceneManager.LoadScene("main-oculus");
        }

        if (ProgressionInterface.getHealth() < 1)
        {
            Debug.Log("Lose");
            SceneManager.LoadScene("lose");
        }
	}
}
