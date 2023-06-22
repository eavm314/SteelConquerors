using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Character
{
    protected override void Start()
    {
        base.Start();
        healthPoints = 100;
        damage = 10;
        speed = 2;
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
