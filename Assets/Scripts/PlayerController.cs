using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public partial class PlayerController : MonoBehaviour
{
    [SerializeField] public float targetPrecision = 1f;
    [SerializeField] public Transform locator;
    public int Direction => _spriteRenderer.flipX ? -1 : 1;

    public Vector3 Position
    {
        get
        {
            var locatorLocalPosition = locator.localPosition;
            var locatorLocalPositionInDirection = new Vector3(
                locatorLocalPosition.x * Direction,
                locatorLocalPosition.y,
                locatorLocalPosition.z);
            return transform.position + locatorLocalPositionInDirection;
        }
    }

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
        var currentXPosition = Position.x;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = _camera.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition = point.x;
            _spriteRenderer.flipX = _targetPosition < currentXPosition;
            IsWalking = true; // TODO: add condition of a distance between target and current, as if distance is too small it shouldn't be possible
        }

        if (IsWalking)
        {
            float stopPosition = currentXPosition + Direction * GetStopOffset();
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

    void OnGui()
    {
        GUI.Label(new Rect(10, 10, 150, 100), "Hello World"); // TODO
        // Thought: it's worth doing a general "GUI debugging" service for stuff like that.
    }
}