using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : Character
{
    protected override void Start()
    {
        base.Start();
        healthPoints = 50;
        damage = 0;
        speed = 1;

    }

    public override void Idle()
    {
        print("revisando...");
    }

    public override void Attack()
    {
        print("atacando...");
    }


}
