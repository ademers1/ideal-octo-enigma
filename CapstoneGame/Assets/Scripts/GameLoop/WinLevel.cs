﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinLevel : MonoBehaviour
{
    public Camera ThirdPersonCamera;
    InventorySystem Inventory;
   

    void Start()
    {
        
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Gameover Enter");
            GameManager.Instance.Camera.ShowMouse();
            SceneManager.LoadScene("Win");
            
        }
    }
}
