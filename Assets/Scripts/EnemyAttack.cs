using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update


    private PlayerHealth attack;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            attack = other.GetComponent<PlayerHealth>();
            Debug.Log(attack);
            if (attack != null)
            {
                attack.Damage(-10);
            }
        }    
    }



}
