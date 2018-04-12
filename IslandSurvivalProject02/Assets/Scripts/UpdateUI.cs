using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {
    public Text civPoints;
    public Text level;
    public Text polPoints;
    public Text stoneCount;
    public Text woodCount;
    public Text seedCount;

	// Update is called once per frame
	void Update () {

        civPoints.text = LevelProgression.getCivPoints().ToString();
        level.text = LevelProgression.getLevel().ToString();
        polPoints.text = LevelProgression.getPollPoints().ToString();
        stoneCount.text = LevelProgression.getStone().ToString();
        woodCount.text = LevelProgression.getWood().ToString();
        seedCount.text = LevelProgression.getSeeds().ToString();

	}
}
