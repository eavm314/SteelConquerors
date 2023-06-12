using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Sprite DeckCard;

    protected int price;
    protected int healthPoints;
    protected int damage;
    protected double speed;

    protected Animator animator;
    protected Collider2D collider;

    public void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 1, 1 << 6);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Robot>().RecieveAttack(damage);
        }
        else
        {
            animator.SetBool("attack", false);
        }

    }

    public void RecieveAttack(int damage)
    {
        healthPoints-=damage;
        if(healthPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        collider.enabled = false;
        animator.SetBool("dead", true);
        Destroy(gameObject, 2);
    }
}
