using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour {

    public Transform player;
    public GameObject[] elementals;
    private int currentRound;
    private int enemyAmt;
    private int i;
    private int enemy;
    private float angle;
    private Vector3 V;
    private float Range;

    // Use this for initialization
    void Start () {
        // Reset player position
        player.position = new Vector3(3000, 10, 3000);

		switch(ProgressionInterface.getRound())
        {
            case 1:
                    // Round 01

                    ProgressionInterface.setEnemyCount(2);  // Set enemy count

                    // Create enemies
                    Instantiate(elementals[1], new Vector3(player.position.x + 10, 0, player.position.z + 30), elementals[1].transform.rotation).transform.LookAt(player);
                    Instantiate(elementals[1], new Vector3(player.position.x - 10, 0, player.position.z + 30), elementals[1].transform.rotation).transform.LookAt(player);
                    break;

            case 2:
                    // Round 02

                    ProgressionInterface.setEnemyCount(3);  // Set enemy count

                    // Create enemies
                    Instantiate(elementals[1], new Vector3(player.position.x + 10, 0, player.position.z + 30), elementals[1].transform.rotation).transform.LookAt(player);
                    Instantiate(elementals[3], new Vector3(player.position.x, 0, player.position.z + 30), elementals[3].transform.rotation).transform.LookAt(player);
                    Instantiate(elementals[1], new Vector3(player.position.x - 10, 0, player.position.z + 30), elementals[1].transform.rotation).transform.LookAt(player);
                    break;

            case 3:
                    // Round 03

                    ProgressionInterface.setEnemyCount(3);  // Set enemy count

                    // Create enemies
                    Instantiate(elementals[1], new Vector3(player.position.x + 10, 0, player.position.z + 30), elementals[1].transform.rotation).transform.LookAt(player);
                    Instantiate(elementals[2], new Vector3(player.position.x, 0, player.position.z + 30), elementals[2].transform.rotation).transform.LookAt(player);
                    Instantiate(elementals[3], new Vector3(player.position.x - 10, 0, player.position.z + 30), elementals[3].transform.rotation).transform.LookAt(player);
                    break;

            case 4:
                    // Round 04

                    ProgressionInterface.setEnemyCount(4);  // Set enemy count

                    // Create enemies
                    Instantiate(elementals[1], new Vector3(player.position.x + 10, 0, player.position.z + 30), elementals[1].transform.rotation).transform.LookAt(player);
                    Instantiate(elementals[2], new Vector3(player.position.x + 3, 0, player.position.z + 30), elementals[2].transform.rotation).transform.LookAt(player);
                    Instantiate(elementals[0], new Vector3(player.position.x - 3, 0, player.position.z + 30), elementals[0].transform.rotation).transform.LookAt(player);
                    Instantiate(elementals[3], new Vector3(player.position.x - 10, 0, player.position.z + 30), elementals[3].transform.rotation).transform.LookAt(player);
                    break;

            default:
                    // Round 5+

                    ProgressionInterface.setEnemyCount(ProgressionInterface.getRound() * 2);    // Set enemy count

                    // Create enemies
                    for (i = 0; i < ProgressionInterface.getEnemyCount(); i++)
                    {
                        // Get a random direction (360°) in radians
                        angle = Random.Range(0.0f, Mathf.PI * 2);

                        // Create a vector with length 1.0
                        V = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));

                        // Get random range away from player
                        Range = Random.Range(30f, 60f);

                        // Scale vector to the desired length
                        V *= Range;

                        // Get random elemental
                        enemy = Random.Range(0, 4);

                        // Spawn elemental
                        Instantiate(elementals[enemy], new Vector3(player.position.x + V.x, 0, player.position.z + V.z), elementals[enemy].transform.rotation).transform.LookAt(player);
                    }
                    break;

        }
	}
}
