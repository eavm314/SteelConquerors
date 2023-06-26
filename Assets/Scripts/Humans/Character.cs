using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Sprite deckCard;

    private SellTroopButton sellTroopButton;

    public int price;
    protected int healthPoints;
    protected int damage;
    protected double speed;

    protected Animator animator;
    protected Collider2D col;

    protected virtual void Start()
    {
        sellTroopButton = FindObjectOfType<SellTroopButton>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    public RaycastHit2D CheckForRobots(float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * 0.75f, Vector2.left, distance,
            LayerMask.GetMask("Robots"));
        return hit;
    }

    public abstract void Idle();

    public abstract void Attack();
    

    public virtual void RecieveAttack(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetTrigger("dead");
        col.enabled = false;
        Destroy(gameObject, 2);
    }

    private void OnMouseDown()
    {
        if (sellTroopButton.toggle.isOn)
        {
            sellTroopButton.SellTroop(this);
            sellTroopButton.toggle.isOn = false;
        }
    }
}
