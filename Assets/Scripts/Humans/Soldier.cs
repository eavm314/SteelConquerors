using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Character
{
    private void Start()
    {
        base.Start();
        healthPoints = 100;
        damage = 20;
        speed = 1;

        print("soldado creado, price: "+price);

    }

    public override void Idle()
    {
        Collider2D robot = CheckForRobots(1).collider;

        if (robot != null)
        {
            animator.SetBool("attack", true);
        }
    }

    public override void Attack()
    {
        Collider2D robot = CheckForRobots(1).collider;

        if (robot != null)
        {
            robot.GetComponent<Robot>().RecieveAttack(damage);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }

}
