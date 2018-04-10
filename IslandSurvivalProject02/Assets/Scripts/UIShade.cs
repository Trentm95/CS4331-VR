using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShade : MonoBehaviour {
    public Shader uishader;
	// Use this for initialization
	void Start () {
        Canvas.GetDefaultCanvasMaterial().shader = uishader;
	}
}
