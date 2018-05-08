using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProgressionInterface {

    // Global Variables
    private static int round = 1;
    private static int playerHealth = 100;
    private static int enemyCount;

    // ROUND METHODS ---------------------------------------------

    public static int getRound()
    {
        return round;
    }

	public static void IncRound()
    {
        round++;
    }


    // ENEMY METHODS ---------------------------------------------

    public static int getEnemyCount()
    {
        return enemyCount;
    }

    // Used to set amount at the beginning of the round
    public static void setEnemyCount(int count)
    {
        enemyCount = count;
    }

    public static void EnemyDeath()
    {
        enemyCount--;
    }


    // PLAYER HEALTH METHODS -------------------------------------

    public static int getHealth()
    {
        return playerHealth;
    }

    public static void SubHealth(int damage)
    {
        playerHealth -= damage;
    }
}
