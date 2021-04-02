using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    Vector3 curDirection;
    bool isFacingLeft;

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



        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        curDirection = new Vector3(h, 0, v);
        curDirection.Normalize();
    }



    private void FixedUpdate()
    {
        //prevents movements after death
        if (!isAlive)
            return;


        Vector3 moveVector = curDirection * speed;
        body.MovePosition(transform.position + moveVector * Time.fixedDeltaTime);
        baseAnim.SetFloat("Speed", moveVector.magnitude);

        //flips sprite towards movement direction

        if (moveVector.x != 0)
            isFacingLeft = moveVector.x < 0;
        FlipSprite(isFacingLeft);
            
        
    }
        
}