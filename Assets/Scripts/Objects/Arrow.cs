using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage;
    public float objectiveDistance;

    private float horizontalSpeed = 5;
    private float verticalSpeed;

    private Rigidbody2D rb;

    private void Awake()
    {
        
    }

    private void Start()
    {
        transform.Rotate(0, 0, 90);
        rb = GetComponent<Rigidbody2D>();

        CalculateVerticalSpeed();
        rb.velocity = Vector3.left * horizontalSpeed + Vector3.up * verticalSpeed;
    }

    private void CalculateVerticalSpeed()
    {
        verticalSpeed = objectiveDistance/(2*horizontalSpeed);
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
