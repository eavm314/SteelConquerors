using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Soldier
{
    [SerializeField] GameObject soldierPrefab;

    public override void RecieveAttack(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 100)
        {
            Instantiate(soldierPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
