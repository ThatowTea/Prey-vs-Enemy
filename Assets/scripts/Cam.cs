using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    public float camSensitivity = 0.1f;
    Vector3 lastMouse = new Vector3(255, 255, 255);
    public float curSpeed = 2f;
    public float maxSpeed = 100;
    public float minSpeed = 2;
    public float slowRange = 20;
    public float NormSpeed = 2f;
    public float NegMaxSpeed = 100;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSensitivity, lastMouse.x * camSensitivity, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;



        if (Input.GetKey(KeyCode.Q))
        {


            gameObject.transform.Translate(Vector3.up * curSpeed * Time.deltaTime);


        }

        if (Input.GetKey(KeyCode.E))
        {



            gameObject.transform.Translate(Vector3.down * curSpeed * Time.deltaTime);


        }

        if (Input.GetKey(KeyCode.J))
        {

            curSpeed = NormSpeed;
            gameObject.transform.Translate(Vector3.left * curSpeed * Time.deltaTime);



        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            curSpeed += 2;
            gameObject.transform.Translate(Vector3.left * curSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.I))
        {
            curSpeed = NormSpeed;
            gameObject.transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);


        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            curSpeed += 2;
            gameObject.transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.K))
        {

            curSpeed = NormSpeed;
            gameObject.transform.Translate(Vector3.back * curSpeed * Time.deltaTime);



        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            curSpeed += 2;
            gameObject.transform.Translate(Vector3.back * curSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.L))
        {
            curSpeed = NormSpeed;
            gameObject.transform.Translate(Vector3.right * curSpeed * Time.deltaTime);



        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            curSpeed += 2;
            gameObject.transform.Translate(Vector3.right * curSpeed * Time.deltaTime);
        }
    }



}



