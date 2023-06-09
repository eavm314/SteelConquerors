using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Character
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        price = 10;
        healthPoints = 100;
        damage = 20;
        speed = 1;


    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("robot!!!");
        print(other);
        animator.SetBool("attack", true);
    }
}
