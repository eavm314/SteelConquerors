using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Merchant : Character
{
    void Start()
    {
        base.Start();
        healthPoints = 100;
        damage = 20;
        speed = 1;
    }

    public Collider2D CheckForResources(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.75f, Vector2.left, distance,
            LayerMask.GetMask("Resources"));

        return hit.collider;
    }

    public override void Idle()
    {
        Collider2D robot = CheckForRobots(1);

        if (robot != null)
        {
            animator.SetBool("attack", true);
        }

        Collider2D gold = CheckForResources(0.5f);
        if (gold != null)
        {
            animator.SetBool("collect", true);
        }
    }

    public override void Attack()
    {
        Collider2D robot = CheckForRobots(1);

        if (robot != null)
        {
            robot.GetComponent<Robot>().RecieveAttack(damage);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }


    public void CollectGold()
    {
        Collider2D gold = CheckForResources(0.5f);
        if (gold != null)
        {
            gold.GetComponent<GoldCell>().CollectGold();
        }
        else
        {
            animator.SetBool("collect", false);
        }
    }
}
