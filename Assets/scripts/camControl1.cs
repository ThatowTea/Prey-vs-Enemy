using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl1 : MonoBehaviour {
    public GameObject cow;
    private Vector3 offset;
	// Use this for initialization
	void Start ()
    {
        offset = transform.position - cow.transform.position;
		
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.transform.position = cow.transform.position + offset;
		
	}
}
