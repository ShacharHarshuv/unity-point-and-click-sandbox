using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public partial class PlayerController : MonoBehaviour
{
    [SerializeField] public float targetPrecision = 1f;
    public int Direction => _spriteRenderer.flipX ? -1 : 1;

    private Camera _camera;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private float _targetPosition = 0;

    private bool IsWalking
    {
        get => _animator.GetBool(AnimationVariable.IsWalking);
        set { _animator.SetBool(AnimationVariable.IsWalking, value); }
    }

    internal static class AnimationVariable
    {
        public static readonly int IsWalking = Animator.StringToHash("isWalking");
    }

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _initializeStopOffset();
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = transform.position.x;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = _camera.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition = point.x;
            _spriteRenderer.flipX = _targetPosition < currentPosition;
            IsWalking = true; // TODO: add condition of a distance between target and current, as if distance is too small it shouldn't be possible
        }

        if (IsWalking)
        {
            float stopPosition = currentPosition + Direction * GetStopOffset();
            float distanceToTarget = Math.Abs(_targetPosition - stopPosition);
            // Debug.Log(offset); // TODO
            // Debug.Log(distanceToTarget); // TODO
            if (distanceToTarget < targetPrecision) // TODO adjust that number ?
            {
                Debug.Log("distanceToTarget: " + distanceToTarget);
                IsWalking = false;
            }
        }
    }
}