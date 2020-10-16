using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public partial class PlayerController : MonoBehaviour
{
    // TODO: think of a way of deriving those from the animation data, to avoid double source of truth
    public float leftStopOffset;
    public float rightStopOffset;

    private float _lastStopPosition;

    public float StopPosition
    {
        get
        {
            var currentState = _animator.GetCurrentAnimatorStateInfo(0);
            float offset;
            if (currentState.IsTag("WalkRight"))
            {
                offset = rightStopOffset;
            } else if (currentState.IsTag("WalkLeft") || currentState.IsTag("IdleToWalkLeft"))
            {
                offset = leftStopOffset;
            }
            else
            {
                return _lastStopPosition;
            } 

            _lastStopPosition = Position.x + Direction * offset;
            return _lastStopPosition;
        }
    }
}