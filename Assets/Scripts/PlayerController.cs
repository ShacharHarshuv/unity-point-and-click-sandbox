using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
git remot
public class PlayerController : MonoBehaviour
{
    public bool IsFlipX => _spriteRenderer.flipX;

    private Camera _camera;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private float _targetPosition = 0;

    private bool _isWalking
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
    }

    // TODO: probably delete those
    private void OnGUI()
    {
        if (Debug.isDebugBuild)
        {
            Event currentEvent = Event.current;
            // Get the mouse position from Event.
            // Note that the y position from Event is inverted.
            Vector2 mousePos = new Vector2
            {
                x = currentEvent.mousePosition.x,
                y = _camera.pixelHeight - currentEvent.mousePosition.y
            };

            Vector3 point = _camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, _camera.nearClipPlane));

            GUILayout.BeginArea(new Rect(20, 20, 250, 120));
            GUILayout.Label("Screen pixels: " + _camera.pixelWidth + ":" + _camera.pixelHeight);
            GUILayout.Label("Mouse position: " + mousePos);
            GUILayout.Label("World position: " + point.ToString("F3"));
            GUILayout.EndArea();
        }
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
            _isWalking = true; // TODO: add condition of a distance between target an current, as if distance is too small it shouldn't be possible
        }

        if (Math.Abs(_targetPosition - currentPosition) < 1) // TODO adjust that number ?
        {
            _isWalking = false;
        }
    }
}