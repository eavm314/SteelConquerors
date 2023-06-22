using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    private float horizontalSpeed = 5;

    private Rigidbody2D rb;

    public void ThrowToHuman(int damage)
    {
        rb = GetComponent<Rigidbody2D>();
        this.damage = damage;

        rb.velocity = Vector2.right * horizontalSpeed;
    }

    private void FixedUpdate()
    {
        if (transform.position.x > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D human)
    {
        if (human != null)
        {
            human.GetComponent<Character>().RecieveAttack(damage);
        }

        Destroy(gameObject);
    }
}
