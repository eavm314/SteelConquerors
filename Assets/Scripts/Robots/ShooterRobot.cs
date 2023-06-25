using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShooterRobot : Robot
{
    public GameObject bulletPrefab;
    protected override void Start()
    {
        base.Start();
        healthPoints = 200;
        damage = 10;
        speed = 0.5f;
        rb.velocity = Vector2.right * speed;
    }

    public override void Run()
    {
        RaycastHit2D human = CheckForHumans(11);

        if (human.collider != null)
        {
            animator.SetFloat("attack", human.distance);
        }
    }

    public override void Attack()
    {
        RaycastHit2D human = CheckForHumans(11);

        if (human.collider != null)
        {
            if (human.distance < 2)
            {
                rb.velocity = Vector2.zero;
            } else
            {
                rb.velocity = Vector2.right * speed;
            }

            ShootLaser();

            animator.SetFloat("attack", human.distance);

        }
        else
        {
            animator.SetFloat("attack", 100);
            rb.velocity = Vector2.right * speed;

        }

    }

    public void ShootLaser()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position + Vector3.up * 0.8f + Vector3.right * 0.9f;
        bullet.GetComponent<Bullet>().ThrowToHuman(damage);
    }

}
