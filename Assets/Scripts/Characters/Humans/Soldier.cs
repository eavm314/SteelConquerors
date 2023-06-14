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

}
