using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    //Access this variable from your script or add proper function in this script 
    public float health;
    public float minHealth;
    public float maxHealth;

    private Slider healthBar;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    void Update()
    {
        UpdateHealthBar();

        health = Mathf.Clamp(health, minHealth, maxHealth);
    }

    void UpdateHealthBar()
    {
        healthBar.value = health;
    }
}