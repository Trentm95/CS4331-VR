using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(AudioSource))]
public class Gather : MonoBehaviour {
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.time = 17F;
    }
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetAxisRaw("Tool") > 0)
        {
            var trees = GameObject.FindGameObjectsWithTag("Tree");

            foreach (GameObject tree in trees)
            {
                if(Vector3.Distance(transform.position,tree.transform.position) < 3)
                {
                    audioSource.Play();
                    Destroy(tree);
                    LevelProgression.AddWood(10);
                    LevelProgression.AddSeeds(5);                 
                }
            }

            var rocks = GameObject.FindGameObjectsWithTag("Rock");

            foreach (GameObject rock in rocks)
            {
                if (Vector3.Distance(transform.position, rock.transform.position) < 30)
                {
                    audioSource.Play();
                    Destroy(rock);
                    LevelProgression.AddStone(10);             
                }
            }

        }
    }
}
