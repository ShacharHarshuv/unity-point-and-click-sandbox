using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public partial class PlayerController : MonoBehaviour
{
    public float leftStopOffset;
    public float rightStopOffset;

    private void _initializeStopOffset() // TODO: delete this function if not needed
    {
        // PlayerAnimationState[] behaviors = _animator.GetBehaviours<PlayerAnimationState>();
        // // TODO: This might not be a good practice as it produces a "double source of truth scenario, with the actual "tag"
        // rightStopOffset = Array.Find(behaviors, behavior => behavior.tag == "WalkRightToIdle").xOffset;
        // leftStopOffset = Array.Find(behaviors, behavior => behavior.tag == "WalkLeftToIdle").xOffset;
        //
        // Debug.Log(rightStopOffset);
        // Debug.Log(leftStopOffset);
    }

    // Start is called before the first frame update
    private float GetStopOffset()
    {
        var currentState = _animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsTag("WalkRight"))
        {
            return rightStopOffset;
        }

        if (currentState.IsTag("WalkLeft") || currentState.IsTag("IdleToWalkLeft"))
        {
            return leftStopOffset;
        }

        return 0;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 20),  "Stopping offset: " + GetStopOffset());
        GUI.Label(new Rect(0,20, 200, 20),  "Position: " + Position);
    }
}