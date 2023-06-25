using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Robot : MonoBehaviour
{
    public int healthPoints;
    protected int damage;
    protected float speed;

    protected Animator animator;

    protected Rigidbody2D rb;
    protected Collider2D col;
    protected virtual void Start()
    {
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    public RaycastHit2D CheckForHumans(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.75f, Vector2.right, distance,
            LayerMask.GetMask("Humans"));
        return hit;
    }

    public abstract void Run();


    public abstract void Attack();
    

    public void RecieveAttack(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetTrigger("dead");
        col.enabled = false;
        rb.velocity = Vector2.zero;
        Destroy(gameObject, 2);
    }

    public void Explode()
    {
        rb.velocity = Vector2.zero;
        animator.SetTrigger("explode");
        Destroy(gameObject, 1);
    }

    public void Win()
    {
        rb.velocity = Vector2.zero;
        animator.SetTrigger("win");
    }
}
