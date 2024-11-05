using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class Spawner : MonoBehaviour {
  
	public GameObject cube;
	
	// Use this for initialization
	
	void Start () 
	{

		for(int i = 0; i < 100; i++)
        	{

            		Instantiate(cube, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
           		Debug.Log(i);
        	}
	
	}
	
	
	// Update is called once per frame
	
	void Update () {

		
	
	}

}
