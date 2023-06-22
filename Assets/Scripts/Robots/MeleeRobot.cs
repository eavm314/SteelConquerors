using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeRobot : Robot
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        healthPoints = 200;
        damage = 20;
        speed = 1;
        rb.velocity = Vector3.right * speed;

    }

}
