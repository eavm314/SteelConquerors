using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShooterRobot : Robot
{
    public GameObject bulletPrefab;

    public override void Run()
    {
        RaycastHit2D human = CheckForHumans(11);

        if (human.collider != null)
        {
            ShootLaser();

            if (human.distance < 2)
            {
                rb.velocity = Vector2.zero;
                animator.SetBool("stop", true);
            }
        }
    }

    public override void Attack()
    {
        RaycastHit2D human = CheckForHumans(11);

        if (human.collider != null)
        {
            ShootLaser();

            if (human.distance > 2)
            {
                rb.velocity = Vector2.right * speed;
                animator.SetBool("stop", false);
            }
        }
        else
        {
            rb.velocity = Vector2.right * speed;
            animator.SetBool("stop", false);
        }

    }

    public void ShootLaser()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position + Vector3.up * 0.8f + Vector3.right * 0.9f;
        bullet.GetComponent<Bullet>().ThrowToHuman(damage);
    }

}
