using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl: MonoBehaviour
{
    public float speed = 5;
    public float rotatespeed = 5;

    // Use this for initialization
    void Start()
    {

    }

    float inputX, inputZ;
    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        if (inputX != 0)
        {
            rotate();
        }
        if (inputZ != 0)
        {
            move();
        }
		if (Input.GetKey(KeyCode.UpArrow)) {
			speed += 5;
			rotatespeed += 5;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			speed -= 3;
			rotatespeed -= 5;
		}
    }

    private void move()
    {
        transform.position += (transform.forward * inputZ * Time.deltaTime) * speed;
    }

    private void rotate()
    {
        transform.Rotate(new Vector3(0f, inputX * Time.deltaTime, 0f) * rotatespeed);
    }

}