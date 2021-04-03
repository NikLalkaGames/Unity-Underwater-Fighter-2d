﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttack : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("I'm applied");
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Actor"))
        {
            Debug.Log("Has hit enemy!");
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Check default collisison");
    }
}
