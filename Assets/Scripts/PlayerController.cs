using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    Vector3 curDirection;
    bool isFacingLeft;

    //variables for attacking
    bool isAttackingAnim;
    float lastAttackTime;
    float attackLimit = 0.14f;

    protected override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        //calls superclass
        base.Update();

        //handles button presses after death
        if (!isAlive)
            return;
        isAttackingAnim = baseAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack");

        // input for movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        curDirection = new Vector3(h, 0, v); // save direction of movement
        curDirection.Normalize();   // normalize vector of movement for calculations

        // input attack
        bool attack = Input.GetButtonDown("Attack");

        // attack logic
        if (attack && Time.time >= lastAttackTime + attackLimit)
        {
            lastAttackTime = Time.time;
            Attack();
        }
    }

    private void FixedUpdate()
    {
        //prevents movements after death
        if (!isAlive)
            return;

        // movement logic
        if (!isAttackingAnim)
        {
            Vector3 moveVector = curDirection * speed;
            body.MovePosition(transform.position + moveVector * Time.fixedDeltaTime);
            baseAnim.SetFloat("Speed", moveVector.magnitude);

            //flips sprite towards movement direction
            if (moveVector.x != 0)
                isFacingLeft = moveVector.x < 0;
            FlipSprite(isFacingLeft);
        }
        
    }

}