using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public partial class PlayerController : MonoBehaviour
{
    private float _leftStopOffset;
    private float _rightStopOffset;

    private void _initializeStopOffset()
    {
        PlayerAnimationState[] behaviors = _animator.GetBehaviours<PlayerAnimationState>();
        // TODO: This might not be a good practice as it produces a "double source of truth scenario, with the actual "tag"
        _rightStopOffset = Array.Find(behaviors, behavior => behavior.tag == "WalkRightToIdle").xOffset;
        _leftStopOffset = Array.Find(behaviors, behavior => behavior.tag == "WalkLeftToIdle").xOffset;
        
        Debug.Log(_rightStopOffset);
        Debug.Log(_leftStopOffset);
    }

    // Start is called before the first frame update
    private float GetStopOffset()
    {
        var currentState = _animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsTag("WalkRight"))
        {
            return _rightStopOffset;
        }

        if (currentState.IsTag("WalkLeft") || currentState.IsTag("IdleToWalkLeft"))
        {
            return _leftStopOffset;
        }

        return 0;
    }

    private void OnGUI()
    {
        // GUI.Label(new Rect(0, 0, 200, 20),  "Stopping offset: " + GetStopOffset());
    }
}