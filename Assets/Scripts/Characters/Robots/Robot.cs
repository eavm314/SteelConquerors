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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("soldado!!!");
        //print(other);
        rb.velocity = Vector3.zero;
        animator.SetBool("attack", true);
    }

    void Attack()
    {
        //Debug.DrawRay(transform.position, Vector2.right, Color.red, 0.1f);
        //print();
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.75f, Vector2.right, 1, LayerMask.GetMask("Humans"));

        if (hit.collider != null)
        {
            hit.collider.GetComponent<Character>().RecieveAttack(damage);
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
