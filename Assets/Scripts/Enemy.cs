using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    FiniteStateMachine fsm;

    public float timeToTurn = 1.5f;
    
    private float turnTimer;
    
    private float spellCooldown;
    
    Vector3 direction = Vector3.right;

    public PlayerDetector playerDetector;

    protected override void Start()
    {
        base.Start();
        fsm = new FiniteStateMachine();
        fsm.SetUpState(Idle);
        Debug.Log("IdleState");
    }

    public void Idle()
    {
        // transition condition
        if (playerDetector.playerIsNearby)
        {
            fsm.TransitTo(Follow);
            Debug.Log("FollowState");
        }
    }

    public void Follow()
    {
        moveVector = direction * speed;
        body.MovePosition(transform.position + moveVector * Time.fixedDeltaTime);
        baseAnim.SetFloat("Speed", moveVector.magnitude);
        
        if ( Vector2.Distance(transform.position, PlayerController.instance.transform.position) <= 2 )
        {
            Attack();
            fsm.TransitTo(Attacking);
            Debug.Log("AttackState");
        }
    }

    public void Attacking()
    {
        // attack logic
        if (Vector2.Distance(transform.position, PlayerController.instance.transform.position) > 2)
        {
            fsm.TransitTo(Follow);
            Debug.Log("FollowState");
        }
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
