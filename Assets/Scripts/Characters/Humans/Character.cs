using System.Collections;
using System.Collections.Generic;
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

    public void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        CheckFront(0.65f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckFront(1);
    }

    public virtual void CheckFront(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.75f, Vector2.left, distance,
            LayerMask.GetMask("Robots"));

        if (hit.collider != null)
        {
            animator.SetBool("attack", true);
        }
    }


    public void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.75f, Vector2.left, 
            1, LayerMask.GetMask("Robots"));

        //Debug.DrawRay(transform.position + Vector3.up * 0.75f, Vector2.left, Color.red, 0.2f);
        //print(hit.collider);

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
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        coll.enabled = false;
        animator.SetBool("dead", true);
        Destroy(gameObject, 2);
    }
}
