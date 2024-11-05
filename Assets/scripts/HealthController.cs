using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// © 2017 TheFlyingKeyboard and released under MIT License
// theflyingkeyboard.net

public class HealthController : MonoBehaviour
{
    public HealthBarController healthBar;

    public float healthChange;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            healthBar.health += healthChange;
        }

        if (Input.GetKey(KeyCode.S))
        {
            healthBar.health -= healthChange;
        }
    }
}