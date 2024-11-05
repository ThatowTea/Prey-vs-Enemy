using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    int health = 100;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	public void EatMe (int biteSize)
    {
        //
        health -= biteSize;

        if(health >= 0)
        {
            Destroy(gameObject);
        }
		
	}
}
