using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimationState : StateMachineBehaviour
{
    [SerializeField]
    public float xOffset = 0;
    
    [SerializeField]
    public string tag;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var direction = animator.GetComponent<PlayerController>().Direction;
        animator.transform.position += Vector3.right * xOffset * direction;
    }
}
