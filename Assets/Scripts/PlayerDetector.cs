using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerDetector : MonoBehaviour {

    public bool playerIsNearby;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
            playerIsNearby = true;
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
            playerIsNearby = false;
    }
}
