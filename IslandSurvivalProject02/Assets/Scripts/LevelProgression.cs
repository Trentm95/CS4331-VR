using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour {
    
    // Global Variables
    private int civPoints;
    private int pollPoints;
    private int level;

	// Use this for initialization
	void Start () {
        civPoints = 0;
        pollPoints = 0;
        level = 1;
	}
	
	// Update is called once per frame
	void Update () {
		// Level up logic

        // Lose condition

        // Win condition
	}



    // CIVILIZATION POINTS METHODS ----------------------------------------------------------------

    public int getCivPoints()
    {
        return civPoints;
    }

    public void AddCivPoints(int points)
    {
        civPoints += points;
    }



    // POLLUTION POINTS METHODS -------------------------------------------------------------------

    public int getPollPoints()
    {
        return pollPoints;
    }

    public void AddPollPoints(int points)
    {
        pollPoints += points;
    }

    public void SubPollPoints(int points)
    {
        pollPoints -= points;
    }



    // LEVEL METHODS ------------------------------------------------------------------------------

    public int getLevel()
    {
        return level;
    }

    public void IncLevel()
    {
        level++;
    }
}
