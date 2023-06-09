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

    public Animator animator;
    public Collider2D col;

    public void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    void Attack()
    {
        //Debug.DrawRay(transform.position, Vector2.right, Color.red, 0.1f);
        //print();
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
        col.enabled = false;
        animator.SetBool("dead", true);
        Destroy(gameObject, 2);
    }
}
