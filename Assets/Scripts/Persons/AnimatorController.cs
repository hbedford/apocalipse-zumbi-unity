using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack(bool value)
    {
        animator.SetBool("attack", value);
    }

    public void Moving(float value)
    {
        animator.SetFloat("moving", value);
    }
}
