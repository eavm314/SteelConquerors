using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : Character
{
    private GoldCell goldCell;
    void Start()
    {
        base.Start();
        healthPoints = 100;
        damage = 20;
        speed = 1;
    }

    public override void CheckFront(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.75f, Vector2.left, distance,
            LayerMask.GetMask("Robots", "Resources"));

        print(hit.collider);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Robot"))
            {
                animator.SetBool("attack", true);
            }
            else if (hit.collider.CompareTag("Gold"))
            {
                goldCell = hit.collider.GetComponent<GoldCell>();
                animator.SetBool("collect", true);
            }
        }
    }

    public void CollectGold()
    {
        goldCell.CollectGold();
    }
}
