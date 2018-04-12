using UnityEngine.SceneManagement;

public static class LevelProgression {
    
    // Global Variables
    private static int civPoints = 0;
    private static int pollPoints = 0;
    private static int level = 1;

    // Resources
    private static int stone = 0;
    private static int wood = 0;
    private static int seeds = 0;


    // CIVILIZATION POINTS METHODS ----------------------------------------------------------------

    public static int getCivPoints()
    {
        return civPoints;
    }

    public static void AddCivPoints(int points)
    {
        civPoints += points;

        if(civPoints >= 5)
        {
            level++;
            civPoints -= 5;

            if(level >= 25 && pollPoints < 50)
            {
                SceneManager.LoadScene("win");
            }
        }
    }


    // POLLUTION POINTS METHODS -------------------------------------------------------------------

    public static int getPollPoints()
    {
        return pollPoints;
    }

    public static void AddPollPoints(int points)
    {
        pollPoints += points;

        if(pollPoints >= 50)
        {
            SceneManager.LoadScene("lose");
        }
    }

    // LEVEL METHODS ------------------------------------------------------------------------------

    public static int getLevel()
    {
        return level;
    }

    public static void incLevel()
    {
        level++;
    }

    // Resource METHODS ------------------------------------------------------------------------------

    public static int getStone()
    {
        return stone;
    }

    public static void AddStone(int amnt)
    {
        stone += amnt;
    }

    public static int getWood()
    {
        return wood;
    }

    public static void AddWood(int amnt)
    {
        wood += amnt;
    }

    public static int getSeeds()
    {
        return seeds;
    }

    public static void AddSeeds(int amnt)
    {
        seeds += amnt;
    }

}
