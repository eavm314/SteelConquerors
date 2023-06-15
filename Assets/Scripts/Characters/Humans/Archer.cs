using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Character
{
    void Start()
    {
        base.Start();
        healthPoints = 100;
        damage = 50;
        speed = 1;
    }

    public override void Idle()
    {
        Collider2D robot = CheckForRobots(100);

        if (robot != null)
        {
            animator.SetBool("attack", true);
        }
    }

    public override void Attack()
    {
        Collider2D robot = CheckForRobots(100);

        if (robot != null)
        {
            ThrowArrow(robot);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }

    public void ThrowArrow(Collider2D robot)
    {
        print("lanzando flecha a: " + robot);
    }
}
