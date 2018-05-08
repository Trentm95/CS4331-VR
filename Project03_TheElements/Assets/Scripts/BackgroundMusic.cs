using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {
   AudioSource src;

    private void Awake()
    {
            src = GetComponent<AudioSource>();
            src.Play();         
    }
}
