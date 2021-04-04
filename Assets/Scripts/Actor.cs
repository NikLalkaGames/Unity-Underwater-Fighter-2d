using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour {
    public Animator baseAnim;
    public Rigidbody body;
    protected bool canFlinch = true;
    public float speed = 2;
    public bool isAlive = true;
    protected Vector3 frontVector;
    public AttackData normalAttack;
    protected bool isFacingLeft;
    protected Vector3 moveVector;

    protected virtual void Start()
    {
        isAlive = true;
        baseAnim.SetBool("IsAlive", isAlive);
    }

    public void FlipSprite(bool isFacingLeft)
    {
        if (isFacingLeft)
        {
            frontVector = new Vector3(-1, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            frontVector = new Vector3(1, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public virtual void Attack()
    {
        baseAnim.SetBool("Attack", true);
    }


    [System.Serializable]
    public class AttackData
    {
        public float attackDamage = 10;
        public float force = 50;
        public bool knockdown = false;
    }
}
