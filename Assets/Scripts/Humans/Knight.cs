using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Character
{
    void Start()
    {
        base.Start();
        
        healthPoints = 500;
        damage = 20;
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