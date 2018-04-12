using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStorm : MonoBehaviour {
    public Transform player;
    public GameObject stormSystem;
    public Camera sky;
    public Light sun;
    private Vector3 offset;
    
    // Use this for initialization
    void Start ()
    {
        sky.backgroundColor = Color.grey;
        sky.clearFlags = CameraClearFlags.SolidColor;
        sun.color = Color.grey;
        stormSystem = Instantiate(stormSystem, new Vector3(player.position.x + 30, player.position.y - 20, player.position.z + 150), stormSystem.transform.rotation);
        offset = stormSystem.transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        stormSystem.transform.position = player.transform.position + offset;
    }

    void OnDisable()
    {
        Destroy(stormSystem);
    }
}
