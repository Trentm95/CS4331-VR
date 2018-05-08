using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
    // OVRInput.Controller.RTouch
    [SerializeField]
    protected OVRInput.Controller rightController;
    // OVRInput.Controller.LTouch
    [SerializeField]
    protected OVRInput.Controller leftController;

    // Selected Element Left UI
    [SerializeField]
    protected Text leftSel;
    // Selected Element Right UI
    [SerializeField]
    protected Text rightSel;

    // OVR Local Avatar
    OvrAvatar avatar;

    // Fire object
    GameObject fire;
    // Water object
    GameObject water;
    // Earth object
    GameObject earth;
    // Air object
    GameObject air;

    // Fire Sound
    AudioClip fireSound;
    // Water Sound
    AudioClip waterSound;
    // Earth Sound
    AudioClip earthSound;
    // Air Sound
    AudioClip airSound;

    // Selected sounds
    AudioClip rightSound;
    AudioClip leftSound;

    // Selected elements
    GameObject rightEl;
    GameObject leftEl;

    // Coutners for debouncing 
    int debounceR;
    int debounceL;

    // Source to play audio
    AudioSource audio;

    void Start () {
        // Initialize
        debounceR = 0;
        debounceL = 0;

        audio  = GetComponent<AudioSource>();

        fire = Resources.Load<GameObject>("Projectiles/fire");
        water = Resources.Load<GameObject>("Projectiles/water");
        earth = Resources.Load<GameObject>("Projectiles/earth");
        air = Resources.Load<GameObject>("Projectiles/air");

        fireSound = Resources.Load<AudioClip>("Sounds/fire_shoot_sound");
        waterSound = Resources.Load<AudioClip>("Sounds/water_shoot_sound");
        earthSound = Resources.Load<AudioClip>("Sounds/earth_shoot_sound");
        airSound = Resources.Load<AudioClip>("Sounds/air_shoot_sound");

        avatar = gameObject.GetComponent<OvrAvatar>();

        rightEl = fire;
        rightSound = fireSound;
        rightSel.text = "Fire";
        rightSel.color = Color.red;

        leftEl = air;
        leftSound = airSound;
        leftSel.text = "Air";
        leftSel.color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        // Dec denounce
        debounceR = debounceR > 0 ? debounceR - 1 : debounceR;
        debounceL = debounceL > 0 ? debounceL - 1 : debounceL;

        // A - Select Water Right
        if (OVRInput.Get(OVRInput.Button.One, rightController))
        {
            rightEl = water;
            rightSound = waterSound;
            rightSel.text = "Water";
            rightSel.color = Color.blue;
        }
        // B - Select Fire Right
        if (OVRInput.Get(OVRInput.Button.Two, rightController))
        {
            rightEl = fire;
            rightSound = fireSound;
            rightSel.text = "Fire";
            rightSel.color = Color.red;
        }
        // X - Select Earth Left
        if (OVRInput.Get(OVRInput.Button.One, leftController))
        {
            leftEl = earth;
            leftSound = earthSound;
            leftSel.text = "Earth";
            leftSel.color = Color.green;
        }
        // Y - Select Air Left
        if (OVRInput.Get(OVRInput.Button.Two, leftController))
        {
            leftEl = air;
            leftSound = airSound;
            leftSel.text = "Air";
            leftSel.color = Color.white;
        }

        // Right shoot
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, rightController) > 0 && debounceR == 0)
        {
            GameObject projectile = Instantiate<GameObject>(rightEl);
            projectile.transform.position = avatar.HandRight.transform.position + avatar.HandRight.transform.forward;
            projectile.transform.rotation = avatar.HandRight.transform.rotation;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = avatar.HandRight.transform.forward * 30;

            debounceR = 30;

            audio.PlayOneShot(rightSound);

            Destroy(projectile, 10);
        }

        // Left shoot
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, leftController) > 0 && debounceL == 0)
        {
            GameObject projectile = Instantiate<GameObject>(leftEl);
            projectile.transform.position = avatar.HandLeft.transform.position + avatar.HandLeft.transform.forward;
            projectile.transform.rotation = avatar.HandLeft.transform.rotation;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = avatar.HandLeft.transform.forward * 60;

            debounceL = 30;

            audio.PlayOneShot(leftSound);

            Destroy(projectile, 10);
        }
    }
}
