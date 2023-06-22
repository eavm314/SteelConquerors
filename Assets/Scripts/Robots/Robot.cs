using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    int healthPoints;
    int damage;
    int speed;

    Animator animator;

    Rigidbody2D rb;
    Collider2D col;
    void Start()
    {
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        healthPoints = 200;
        damage = 20;
        speed = 1;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.right * speed;

    }

    public Collider2D CheckForHumans(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.75f, Vector2.right, distance,
            LayerMask.GetMask("Humans"));
        return hit.collider;
    }

    public void Run()
    {
        Collider2D human = CheckForHumans(1);

        if (human != null)
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("attack", true);
        }
    }

    public void Attack()
    {
        Collider2D human = CheckForHumans(1);

        if (human != null)
        {
            human.GetComponent<Character>().RecieveAttack(damage);
        }
        else
        {
            rb.velocity = Vector3.right * speed;
            animator.SetBool("attack", false);
        }

    }

    public void RecieveAttack(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            //animator.SetBool("dead", true);
            animator.SetTrigger("dead");
        }
    }

    public void Die()
    {
        col.enabled = false;
        rb.velocity = Vector3.zero;
        Destroy(gameObject, 2);
    }

}
