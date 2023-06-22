using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeRobot : Robot
{
    protected override void Start()
    {
        base.Start();
        healthPoints = 200;
        damage = 20;
        speed = 1;
        rb.velocity = Vector2.right * speed;

    }
    public override void Run()
    {
        RaycastHit2D human = CheckForHumans(1);

        if (human.collider != null)
        {
            rb.velocity = Vector2.zero;
            animator.SetBool("attack", true);
        }
    }

    public override void Attack()
    {
        RaycastHit2D human = CheckForHumans(1);

        if (human.collider != null)
        {
            human.collider.GetComponent<Character>().RecieveAttack(damage);
        }
        else
        {
            rb.velocity = Vector2.right * speed;
            animator.SetBool("attack", false);
        }

    }

}
