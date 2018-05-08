using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawUI : MonoBehaviour {

    [SerializeField]
    protected Text round;

    [SerializeField]
    protected Image health;

    [SerializeField]
    protected Text enemies;
	
	// Update is called once per frame
	void Update () {

        round.text = "Round " + ProgressionInterface.getRound().ToString();
        enemies.text = "Enemies " + ProgressionInterface.getEnemyCount().ToString();
        health.fillAmount = ProgressionInterface.getHealth() / 100.0f;
	}
}
