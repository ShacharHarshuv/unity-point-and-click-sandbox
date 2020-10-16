using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Put those on "stopping" state
 */
public class PlayerTargetCorrection : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var playerController = animator.GetComponent<PlayerController>();
        var correction = playerController.TargetPosition - playerController.StopPosition;
        playerController.transform.position += Vector3.right * correction;
    }
}
