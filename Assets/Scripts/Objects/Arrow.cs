using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private int damage;
    private float horizontalSpeed = 5;
    private float verticalSpeed;
    private float maxHeight = 2;
    private float timeToImpact;

    private Rigidbody2D rb;

    public void ThrowToRobot(float objectiveDistance, int damage)
    {
        transform.Rotate(0, 0, 90);
        rb = GetComponentInChildren<Rigidbody2D>();
                                         
        this.damage = damage;
        this.timeToImpact = objectiveDistance / horizontalSpeed;
        this.verticalSpeed = (2 * horizontalSpeed * maxHeight) /(objectiveDistance);

        rb.gravityScale = (-(verticalSpeed*verticalSpeed) / (maxHeight))/Physics2D.gravity.y;

        rb.velocity = Vector3.up * verticalSpeed;
        Destroy(gameObject, timeToImpact);
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3.left*horizontalSpeed)/50;
    }

    private void OnTriggerEnter2D(Collider2D robot)
    {
        if (robot != null)
        {
            robot.GetComponent<Robot>().RecieveAttack(damage);
        }

        Destroy(gameObject);
    }
}
