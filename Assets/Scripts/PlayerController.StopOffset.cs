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

    // private void OnGUI()
    // {
    //     GUI.Label(new Rect(0, 0, 200, 20),  "Stopping offset: " + GetStopOffset());
    //     GUI.Label(new Rect(0,20, 200, 20),  "Position: " + Position);
    // }
}