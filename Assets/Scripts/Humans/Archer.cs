using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Character
{
    public GameObject arrowPrefab;
    protected override void Start()
    {
        base.Start();
        healthPoints = 100;
        damage = 50;
        speed = 1;
    }

    public override void Idle()
    {
        Collider2D robot = CheckForRobots(11.5f).collider;

        if (robot != null)
        {
            animator.SetBool("attack", true);
        }
    }

    public override void Attack()
    {
        RaycastHit2D robotHit = CheckForRobots(11.5f);

        if (robotHit.collider != null)
        {
            ThrowArrow(robotHit.distance);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }

    public void ThrowArrow(float distance)
    {
        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = transform.position + Vector3.up * 0.75f;
        arrow.GetComponent<Arrow>().ThrowToRobot(distance+2, damage);

    }
}
