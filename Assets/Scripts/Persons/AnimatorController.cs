using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    bool lastStateAttack = false;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Attack(bool value, System.Action callBack =null)
    {
        animator.SetBool("attack", value);

        if(lastStateAttack && !value && callBack!=null)
        {
            callBack();
        }
        lastStateAttack = value;
    }

    public void Moving(float value)
    {
        animator.SetFloat("moving", value);
    }

    
}
