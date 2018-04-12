using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDisaster : MonoBehaviour {
    public GameObject player;
    public Camera sky;
    public Light sun;
    private float timer;
    private bool done;

	// Use this for initialization
	void Start () {
        timer = 0f;
        done = false;
    }
	
	// Update is called once per frame
	void Update () {
        print(LevelProgression.getLevel());
        switch(LevelProgression.getLevel())
        {
            case 5:     // Enable storm
                        if (!done)
                        {
                            if (player.GetComponent<SpawnStorm>().enabled == false)
                            {
                                player.GetComponent<SpawnStorm>().enabled = true;
                                LevelProgression.AddPollPoints(5);
                            }

                            if (timer >= 30f)
                            {
                                // Disable storm
                                player.GetComponent<SpawnStorm>().enabled = false;
                                sky.clearFlags = CameraClearFlags.Skybox;
                                sun.color = new Color(1f, 0.9568627450980392f, 0.8392156862745098f);
                                timer = 0f;
                                done = true;
                            }
                            else
                            {
                                timer += Time.deltaTime;
                            }
                            print(timer);
                        }
                        break;

            case 6:     // Reset done
                        done = false;

                        // Disable storm if level up occurs before animation is finished
                        if (player.GetComponent<SpawnStorm>().enabled == true)
                        {
                            // Disable storm
                            player.GetComponent<SpawnStorm>().enabled = false;
                            sky.clearFlags = CameraClearFlags.Skybox;
                            sun.color = new Color(1f, 0.9568627450980392f, 0.8392156862745098f);
                            timer = 0f;
                        }
                       break;

            case 10:    // Enable tornado
                        if (!done)
                        {
                            if (player.GetComponent<SpawnTornado>().enabled == false)
                            {
                                player.GetComponent<SpawnTornado>().enabled = true;
                                LevelProgression.AddPollPoints(5);
                            }

                            if (timer >= 60f)
                            {
                                // Disable storm
                                player.GetComponent<SpawnTornado>().enabled = false;
                                sky.clearFlags = CameraClearFlags.Skybox;
                                sun.color = new Color(1f, 0.9568627450980392f, 0.8392156862745098f);
                                timer = 0f;
                                done = true;
                            }
                            else
                            {
                                timer += Time.deltaTime;
                            }
                            print(timer);
                        }
                        break;

            case 11:     // Reset done
                        done = false;

                        // Disable tornado if level up occurs before animation is finished
                        if (player.GetComponent<SpawnTornado>().enabled == true)
                        {
                            // Disable storm
                            player.GetComponent<SpawnTornado>().enabled = false;
                            sky.clearFlags = CameraClearFlags.Skybox;
                            sun.color = new Color(1f, 0.9568627450980392f, 0.8392156862745098f);
                            timer = 0f;
                        }
                        break;

            case 15:    // Enable tsunami
                        break;

            case 16:     // Reset done
                        done = false;
                        break;

            case 20:    // Enable volcano
                        if (!done)
                        {
                            if (player.GetComponent<SpawnVolcano>().enabled == false)
                            {
                                player.GetComponent<SpawnVolcano>().enabled = true;
                                LevelProgression.AddPollPoints(10);
                            }

                            if (timer >= 30f)
                            {
                                // Disable storm
                                player.GetComponent<SpawnVolcano>().enabled = false;
                                timer = 0f;
                                done = true;
                            }
                            else
                            {
                                timer += Time.deltaTime;
                            }
                            print(timer);
                        }
                        break;
        }
    }
}
