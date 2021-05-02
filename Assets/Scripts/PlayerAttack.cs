using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private EnemyHealth attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            attack = other.GetComponent<EnemyHealth>();
            Debug.Log(attack);
            if (attack != null)
            {
                attack.Damage(-10);
            }
        }    
    }
}
