using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //THIS SHOULD LOOK AT THE CURRENT ACTIVE CAMERA
        transform.LookAt(Camera.main.transform);
	}
}
