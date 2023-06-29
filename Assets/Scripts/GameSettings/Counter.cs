using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private Animator animator;
    private TextMeshProUGUI count;

    public int value = 10;

    private void Start()
    {
        animator = GetComponent<Animator>();
        count = GetComponent<TextMeshProUGUI>();
        count.text = value.ToString();
    }

    private void UpdateCounter()
    {
        value--;
        animator.SetInteger("value", value);
        count.text = value.ToString();
    }
}
