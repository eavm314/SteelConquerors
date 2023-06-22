using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Sprite deckCard;

    public int price;
    protected int healthPoints;
    protected int damage;
    protected double speed;

    protected Animator animator;
    protected Collider2D coll;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        //CheckForRobots(0.65f);
    }

    public RaycastHit2D CheckForRobots(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.75f, Vector2.left, distance,
            LayerMask.GetMask("Robots"));
        return hit;
    }

    public abstract void Idle();

    public abstract void Attack();
    

    public void RecieveAttack(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            animator.SetBool("dead", true);
        }
    }

    public void Die()
    {
        coll.enabled = false;
        Destroy(gameObject, 2);
    }
}
