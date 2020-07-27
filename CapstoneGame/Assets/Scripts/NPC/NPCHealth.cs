﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealth : MonoBehaviour
{

    public int enemyMaxhealth;
    public int enemyCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCurrentHealth <= 0)
        {
            //Replace with enemy death animation
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        enemyCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxhealth;
    }
}
