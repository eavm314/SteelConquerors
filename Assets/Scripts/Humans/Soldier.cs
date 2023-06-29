using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Character
{
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
