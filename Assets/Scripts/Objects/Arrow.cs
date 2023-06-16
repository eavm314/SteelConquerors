using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage;

    private float speed = 5;
    private Rigidbody2D rb;

    void Start()
    {
        transform.Rotate(0, 0, 90);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.left * speed;
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
