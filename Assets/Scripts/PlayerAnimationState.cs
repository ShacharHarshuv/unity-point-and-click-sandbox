﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationState : StateMachineBehaviour
{
    public float xOffsetOnEnter = 0;
    public float xOffsetOnExit = 0;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position += Vector3.right * xOffsetOnEnter * GetDirection(animator);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position += Vector3.right * xOffsetOnExit * GetDirection(animator);
    }

    private int GetDirection(Animator animator)
    {
        return animator.GetComponent<PlayerController>().IsFlipX ? -1 : 1;
    }
}
