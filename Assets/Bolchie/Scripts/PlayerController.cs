using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // transform and physics variables //
    
    [SerializeField] private Vector2 speed =  new Vector2(5f, 3f);

    private Vector2 movement = new Vector3();

    private Vector3 velocity = Vector3.zero;
    
    [SerializeField] private float movementSmooth = 0.2f;


    float groundRadius = 0.2f;

    public Transform groundCheck;

    private Animator anim;

    private bool facingRight = true;

    
    [SerializeField] private float jumpForce = 300f;


    public LayerMask whatIsGround;

    //variable for how high player jumps//

    public Rigidbody2D rb { get; set; }
    
    bool grounded = false;

    bool dead = false;

    bool attack = false;

    bool isJumping = false;

    bool isLanding = false;
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate() 
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        if (!dead && !attack)
        {
            Vector3 targetVelocity = new Vector3(movement.x * speed.x, movement.y * speed.y);

            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmooth);

            anim.SetFloat("Speed", Mathf.Abs(movement.magnitude));

            if (movement.x > 0 && !facingRight && !dead && !attack)
            {
                Flip(movement.x);
            }
            else if (movement.x < 0 && facingRight && !dead && !attack)
            {
                Flip(movement.x);
            }
        }
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.LeftAlt) && !dead)
        {
            attack = true;
            anim.SetBool("Attack", true);
            anim.SetFloat("Speed", 0);

        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            attack = false;
            anim.SetBool("Attack", false);
        }

        if (grounded && Input.GetKeyDown(KeyCode.Space) && !dead)
        {
            anim.SetBool("Ground", true);
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (grounded && Input.GetKeyUp(KeyCode.Space)  && !dead)
        {
            anim.SetBool("Ground", false);
        }

        //dead animation for testing//
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!dead)
            {
                anim.SetBool("Dead", true);
                anim.SetFloat("Speed", 0);
                dead = true;
            }
        }
        
        if (dead)
        {
            anim.SetBool("Dead", false);
            dead = false;
        }
    }

    private void Flip(float horizontal)
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
