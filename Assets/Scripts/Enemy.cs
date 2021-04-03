using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{

    FiniteStateMachine fsm;

    public float timeToTurn;
    
    private float turnTimer;
    
    private float spellCooldown;
    
    Vector3 direction = Vector3.right;

    public PlayerDetector playerDetector;
    

    protected override void Start()
    {
        base.Start();
        fsm = new FiniteStateMachine();
        fsm.SetUpState(Idle);
    }


    public void Idle()
    {
        baseAnim.SetFloat("Speed", 0f);
        baseAnim.SetBool("Attack", false);



        if (turnTimer > 0)
        {
            turnTimer -= Time.fixedDeltaTime;
        }
        else
        {
            turnTimer = timeToTurn;
            if ((playerDetector.playerIsNearby) && (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > 1.5f))
            {
                fsm.TransitTo(Follow);
            }
            if ((playerDetector.playerIsNearby) && (Vector3.Distance(transform.position, PlayerController.instance.transform.position) <= 1.5f))
            {
                fsm.TransitTo(Attacking);
            }
        }
    }


    public void Follow()
    {
        moveVector = direction * speed;
        body.MovePosition(transform.position + moveVector * Time.fixedDeltaTime);
        baseAnim.SetFloat("Speed", moveVector.magnitude);

        if ( Vector3.Distance(transform.position, PlayerController.instance.transform.position) <= 1.5f )
        {
            fsm.TransitTo(Idle);
        }
    }


    public void Attacking()
    {
        Debug.Log("Attacking");
        baseAnim.SetBool("Attack", true);
        fsm.TransitTo(Idle);
        
    }

    private void Update()
    {
        direction = (PlayerController.instance.transform.position - transform.position).normalized;

        if (direction.x != 0)
            isFacingLeft = direction.x < 0;
        FlipSprite(isFacingLeft);
    }
    
    public void FixedUpdate()
    {
        fsm.UpdateState();
    }
}
