using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTornado : MonoBehaviour {
    public Transform player;
    public GameObject tornado;
    public Light sun;
    public Camera sky;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        sky.backgroundColor = Color.grey;
        sky.clearFlags = CameraClearFlags.SolidColor;
        sun.color = Color.grey;
        tornado = Instantiate(tornado, new Vector3(player.position.x + 500, 70, player.position.z + 500), tornado.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        tornado.transform.Translate(new Vector3(-10, 10, 0) * Time.deltaTime);
    }

    void OnDisable()
    {
        Destroy(tornado);
    }
}
