using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    // For the animation of the monster plant

    public Monster monsta;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(monsta.currentState == MonsterStatus.attack)
        {
            animator.SetBool("characterInRange",true);
        }
        else if (monsta.currentState == MonsterStatus.idle)
        {
            animator.SetBool("characterInRange",false);
        }
    }
}
