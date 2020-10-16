using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public partial class PlayerController : MonoBehaviour
{
    private static class AnimationVariable
    {
        public static readonly int IsWalking = Animator.StringToHash("isWalking");
    }
}