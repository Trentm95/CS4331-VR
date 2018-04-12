using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Building
{
    public GameObject obj { get; set; }
    public string name { get; set; }
    public int civVal { get; set; }
    public int polVal { get; set; }
    public int woodCost { get; set; }
    public int stoneCost { get; set; }
    public int seedCost { get; set; }
    public int lvlReq { get; set; }

    public Building(GameObject o, string n, int c, int p, int w, int s, int sd, int l)
    {
        obj = o;
        name = n;
        civVal = c;
        polVal = p;
        woodCost = w;
        stoneCost = s;
        seedCost = sd;
        lvlReq = l;
    }
}

public class Spawner : MonoBehaviour {
    public float spawnDistance;
    public Text selectedName;
    public Text selectedInfo;
    public Transform player;
    public GameObject[] objects = new GameObject[5];
    private Building[] buildings;
    private int index = 0;
    private bool dpBusy = false;

    private void Start()
    {
        // Init buildings
        buildings = new Building[5];

        buildings[0] = new Building(objects[0], "Tent", 2, 2, 1, 0, 0, 0);
        buildings[1] = new Building(objects[1], "Bush", 0, -2, 0, 0, 1, 5);
        buildings[2] = new Building(objects[2], "House", 5, 5, 2, 1, 0, 10);
        buildings[3] = new Building(objects[3], "Well", 2, -5, 0, 5, 1, 15);
        buildings[4] = new Building(objects[4], "Factory", 25, 25, 20, 20, 1, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Spawn")) // Spawn building
        {
            SpawnObject();
        }
        if (CrossPlatformInputManager.GetAxisRaw("DHoriz") < 0 && !dpBusy) // Cycle left through buildings
        {
            dpBusy = true;
            index = (index > 0) ? index - 1 : 0;
        }
        if (CrossPlatformInputManager.GetAxisRaw("DHoriz") > 0 && !dpBusy) // Cycle left through buildings
        {
            dpBusy = true;
            index = (index < 4) ? index + 1 : 4;
        }
        if(CrossPlatformInputManager.GetAxisRaw("DHoriz") == 0) // Debounce dpad
        {
            dpBusy = false;
        }

        // Update UI
        selectedName.text = "<" + buildings[index].name + " Lvl " + buildings[index].lvlReq + ">";
        selectedInfo.text = buildings[index].civVal + " Civ "
            + buildings[index].polVal + " Pol "
            + buildings[index].woodCost + " Wood "
            + buildings[index].stoneCost + " Stone "
            + buildings[index].seedCost + " Seeds";
}

    void SpawnObject()
    {
        Building building = buildings[index];
        if (LevelProgression.getLevel() >= building.lvlReq &&
            LevelProgression.getWood() >= building.woodCost && 
            LevelProgression.getStone() >= building.stoneCost && 
            LevelProgression.getSeeds() >= building.seedCost) // Check if buildable
        {
            // Update game values
            LevelProgression.AddCivPoints(building.civVal);
            LevelProgression.AddPollPoints(building.polVal);
            LevelProgression.AddSeeds(-1 * building.seedCost);
            LevelProgression.AddWood(-1 * building.woodCost);
            LevelProgression.AddStone(-1 * building.stoneCost);

            // Calc location to spawn
            GameObject prefab = building.obj;
            Vector3 playerPos = player.transform.position;
            Vector3 playerDirection = player.transform.forward;
            Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
            spawnPos.Set(spawnPos.x, spawnPos.y, spawnPos.z);

            // Spawn new object
            Instantiate(prefab, spawnPos, prefab.transform.rotation);
        }

    }
}
