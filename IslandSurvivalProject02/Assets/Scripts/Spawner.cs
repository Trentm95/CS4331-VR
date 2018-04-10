using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Spawner : MonoBehaviour {
    public float spawnDistance;
    public Text selectedName;
    public Transform player;
    public GameObject[] objects = new GameObject[5];
    private string[] objectNames = { "Tent", "House", "Detoxifier Well", "Factory", "Purifying Bush" };
    private int index = 0;
    private bool dpBusy = false;

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Spawn"))
        {
            SpawnObject();
        }
        if (CrossPlatformInputManager.GetAxisRaw("DHoriz") < 0 && !dpBusy)
        {
            dpBusy = true;
            index = (index > 0) ? index - 1 : 0;
            selectedName.text = objectNames[index];
        }
        if (CrossPlatformInputManager.GetAxisRaw("DHoriz") > 0 && !dpBusy)
        {
            dpBusy = true;
            index = (index < 4) ? index + 1 : 4;
            selectedName.text = objectNames[index];
        }
        if(CrossPlatformInputManager.GetAxisRaw("DHoriz") == 0)
        {
            dpBusy = false;
        }
    }

    void SpawnObject()
    {
        GameObject prefab = objects[index];
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        spawnPos.Set(spawnPos.x, spawnPos.y, spawnPos.z);

        var obj = Instantiate(prefab, spawnPos, prefab.transform.rotation);
    }
}
